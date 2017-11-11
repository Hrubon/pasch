using System;
using System.Data.SQLite;
using System.IO;

using Settings = RadioServer.Properties.Settings;


namespace RadioServer
{
    public static class Server
    {
        // Dependent services
        static IBroadcastDatabase db;
        static IAuthenticator authenticator;
        static IAuthorizator authorizator;
        static Playback playback;
        static FileStore store;
        static BroadcastScheduler scheduler;
        static RsaCrpyter crypter;
        static SessionManager sessions;
        static TcpServer server;
        static RequestReciever reciever;



        public static void Run()
        {
            var settings = Settings.Default;

            // Initialization
            db = InitDatabase(settings); if (db == null) return;
            authenticator = InitAuthenticator(settings); if (authenticator == null) return;
            authorizator = InitAuthorizator(settings); if (authorizator == null) return;
            playback = InitPlayback(settings); if (playback == null) return;
            store = InitFileStore(settings); if (store == null) return;
            scheduler = InitScheduler(settings, db, store, playback); if (scheduler == null) return;
            crypter = InitCrypter(settings); if (crypter == null) return;
            sessions = InitSessionManager(); if (sessions == null) return;
            server = InitTcpServer(settings); if (server == null) return;
            reciever = InitReciever(settings, server, crypter, authenticator,  authorizator); if (reciever == null) return;

            ProgramOutput.Info("SERVER INITIALIZATION COMPLETED SUCCESSFULLY !!!\r\n");

            // Start server
            scheduler.StartChecking();
            ProgramOutput.Info("Scheduler started.");

            server.StartListening();
            ProgramOutput.Info("Server is listening on TCP port {0}...", server.Port);
        }


        public static void Abort()
        {
            server.StopListening();
            scheduler.StopChecking();
            playback.Stop();
            db.Connection.Close();
        }



        private static IBroadcastDatabase InitDatabase(Settings settings)
        {
            string connString = string.Format(settings.SQLITE_CONN_STRING, settings.DB_FILE);
            var db = new SQLiteConnection(connString);
            var database = new SQLiteDatabase(db, (int)settings.SCHEDULER_PADDING_START, (int)settings.SCHEDULER_PADDING_END);
            database.Open();
            //database.Add(new BroadcastInfo("Kaufmann", DateTime.Now.AddMinutes(3), new TimeSpan(0, 3, 0), BroadcastType.Reservation));
            //database.Add(new BroadcastInfo("Nosková", DateTime.Now.AddMinutes(7), new TimeSpan(0, 5, 0), BroadcastType.Reservation));
            MasterContainer.AddService<IBroadcastDatabase>(database);
            ProgramOutput.Info("Database connection to {0} is up.", settings.DB_FILE);

            return database;
        }

        private static T InitLdap<T>(Settings settings, Func<LdapCredentials, T> init) where T : class
        {
            var creds = new LdapCredentials(settings.LDAP_USERNAME, settings.LDAP_PASSWORD, settings.LDAP_DOMAIN, settings.LDAP_OU);
            try
            {
                return init(creds);
            }
            catch (System.DirectoryServices.AccountManagement.PrincipalServerDownException ex)
            {
                ProgramOutput.Error("LDAP server could not be contacted. Please ensure that machine DNS settings and DNS server is propely configured to reach domain controller. Also make sure that server is on the network.", ex);
                return null;
            }
            catch (System.Security.Authentication.AuthenticationException ex)
            {
                ProgramOutput.Error("Connection to LDAP server failed, because of invalid credentials. Please check config file.", ex);
                return null;
            }
            catch (Exception ex)
            {
                ProgramOutput.Error("Cannot init LDAP connection.", ex);
                return null;
            }
        }

        private static IAuthenticator InitAuthenticator(Settings settings)
        {
            var authenticator = InitLdap(settings, delegate (LdapCredentials creds)
            {
#if DEBUG
                var auth = new DummyAuthenticator();
#else
                var auth = new LdapAuthenticator(creds);
                auth.Connect();
#endif

                return auth;
            });
            var authenticatorCache = new AuthenticatorCache(authenticator, (int)settings.SECURITY_CACHE_EXPIRATION);
            MasterContainer.AddService<IAuthenticator>(authenticatorCache);
            ProgramOutput.Info("Authenticator initialized, LDAP connection to {0} up.", authenticator.ConnectedServer);

            return authenticatorCache;
        }

        private static IAuthorizator InitAuthorizator(Settings settings)
        {
            // Init LDAP authorizator
            var authorizator = InitLdap(settings, delegate (LdapCredentials creds)
            {
#if DEBUG
                var auth = new DummyAuthorizator();
#else
                var auth = new LdapAuthorizator(creds);
                auth.Connect();
#endif

                return auth;
            });

            var authorizatorCache = new AuthorizatorCache(authorizator, (int)settings.SECURITY_CACHE_EXPIRATION);
            MasterContainer.AddService<IAuthorizator>(authorizatorCache);

            // Load LDAP permission binding from def file
            var permissionCfgFile = Properties.Settings.Default.LDAP_PERMISSION_DEF_FILE;
            string[] permissionCfg;
            try
            {
                permissionCfg = File.ReadAllLines(permissionCfgFile);
            }
            catch (Exception ex)
            {
                ProgramOutput.Error("Cannot process LDAP permission binding file {0}, because of following reason:\r\n{1}", permissionCfgFile, ex.Message);
                return null;
            }
            try
            {
                PermissionAttributeEditor.AddAttribFromConfig(permissionCfg, LdapAuthorizator.LDAP_GROUP_ATTRIBUTE,
                    (groupName) => groupName.ToString());
            }
            catch
            {
                ProgramOutput.Error("Cannot process LDAP permission binding file {0}. Invalid syntax.");
                return null;
            }
            ProgramOutput.Error("Authorizator initialized, LDAP connection to {0} up.", authorizator.ConnectedServer);

            return authorizatorCache;
        }

        private static Playback InitPlayback(Settings settings)
        {

            Playback playback;
            try
            {
                playback = new Playback((int)settings.PLAYBACK_DEV_OUT);
                if (playback.OutDevNumber < 0 || playback.OutDevNumber > playback.OutputsCount)
                {
                    ProgramOutput.Error("Cannot initialize playback, invalid output device index. Index must be between 0 and {1}.", playback.OutputsCount);
                    return null;
                }
            }
            catch (Exception ex)
            {
                ProgramOutput.Error("Cannot initialize playback audio output, error: {0}", ex.Message);
                return null;
            }

            MasterContainer.AddService<Playback>(playback);

            ProgramOutput.Info("Playback initialized, output set to: device index = {0} - ({1}).", playback.OutDevNumber, playback.OutName);

            return playback;
        }

        private static FileStore InitFileStore(Settings settings)
        {
            string path = settings.FILE_STORE_ROOT;
            FileStore store;
            try
            {
                store = new FileStore(path);
            }
            catch (UnauthorizedAccessException)
            {
                ProgramOutput.Error("Cannot init audio file store at location {0}. Permission denied.", path);
                return null;
            }
            catch
            {
                ProgramOutput.Error("Cannot init audio file store at location {0}. Please check that the path is valid.", path);
                return null;
            }
            MasterContainer.AddService<FileStore>(store);
            ProgramOutput.Info("Audio file store set to location: {0}.", store.PathRoot);

            return store;
        }

        private static BroadcastScheduler InitScheduler(Settings settins, IBroadcastDatabase db, FileStore store, Playback playback)
        {
            BroadcastScheduler scheduler;
            try
            {
                scheduler = new BroadcastScheduler(db, store, playback, (int)settins.SCHEDULER_CHECK_INTERVAL);
            }
            catch
            {
                ProgramOutput.Error("Cannot initialize scheduler. Please check the scheduler parameters in config file.");
                return null;
            }
            MasterContainer.AddService<BroadcastScheduler>(scheduler);

            return scheduler;
        }

        private static RsaCrpyter InitCrypter(Settings settings)
        {
            RsaCrpyter crypter = null;
            string keyFile = settings.KEYS_FILE;
            if (File.Exists(keyFile))
            {
                string xml = null;
                try
                {
                    ProgramOutput.Info("Loading RSA key pair from file {0}...", keyFile);
                    xml = File.ReadAllText(keyFile);
                }
                catch
                {
                    ProgramOutput.Error("Error accessing RSA key file {0}. Please check permissions to this file.", keyFile);
                    Console.ReadKey(true);
                    return null;
                }
                try
                {
                    crypter = new RsaCrpyter(xml);
                }
                catch
                {
                    ProgramOutput.Error("Error parsing RSA key file {0}. Maybe the file is corrupted or invalid format. Please delete the file to generate new RSA key pair.", keyFile);
                    Console.ReadKey(true);
                    return null;
                }
            }
            else
            {
                ProgramOutput.Info("Generating new RSA key pair into file {0}...", keyFile);
                crypter = new RsaCrpyter();
                string xml = crypter.GetFullXmlConfig();
                try
                {
                    File.WriteAllText(keyFile, xml);
                }
                catch
                {
                    ProgramOutput.Error("Error accessing RSA key file {0}. Please check permissions to this file.", keyFile);
                    Console.ReadKey(true);
                    return null;
                }
            }
            MasterContainer.AddService<RsaCrpyter>(crypter);
            ProgramOutput.Info("RSA crypto module successfuly initialized.");

            return crypter;
        }


        private static SessionManager InitSessionManager()
        {
            var manager = new SessionManager();
            MasterContainer.AddService<SessionManager>(manager);

            return manager;
        }


        private static TcpServer InitTcpServer(Settings settings)
        {
            var server = new TcpServer((int)settings.CONTROL_TCP_PORT);
            MasterContainer.AddService<TcpServer>(server);
            ProgramOutput.Info("TCP socket initialized, ready on port {0}.", server.Port);

            return server;
        }

        private static RequestReciever InitReciever(Settings settings, TcpServer server, RsaCrpyter crypter, IAuthenticator authenticator, IAuthorizator authorizator)
        {
            var reciever = new RequestReciever(server, crypter, authenticator, authorizator);
            reciever.NetProblem += LogIncident;
            reciever.UnrecognizedRequest += LogIncident;
            reciever.Unauthorized += LogIncident;
            reciever.AccessDenied += LogIncident;
            reciever.ExecuteError += LogIncident;
            reciever.InvalidResponse += LogIncident;

            return reciever;
        }



        private static void LogIncident(Request request, Exception ex)
        {
            string message = (ex == null) ? request.ToString() : string.Format("{0}: {1}", (request != null) ? request.ToString() : "", ex.Message);
            ProgramOutput.Error(message);
        }
    }
}