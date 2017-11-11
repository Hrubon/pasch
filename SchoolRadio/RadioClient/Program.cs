using System;
using System.Threading;
using System.Windows.Forms;

using Settings = RadioClient.Properties.Settings;


namespace RadioClient
{
    public static class Program
    {
        private static string appGuid = "14A32363-77BE-46F5-BF3B-4A96A66BC86F";



        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                Application.EnableVisualStyles();

                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Program již na tomto počítači běží!", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var settings = Settings.Default;
                var sender = InitTcpSender(settings);
                if (sender == null) return;

#if DEBUG
                // System.Threading.Thread.Sleep(3000);
#endif
                // Get server public key to encrypt exchange request by RSA
                sender.AsymetricCrypter = GetServerKey(settings, sender);
                if (sender.AsymetricCrypter == null) return;
                // Do symetric AES key exchange with server for the rest of the session
                bool keyExchanged = ExchangeKey(sender);
                if (!keyExchanged)
                    return;

                var login = new LoginForm();
                login.ShowDialog();

                if (login.Result == AuthenticationResult.Granted)
                {
                    MasterContainer.AddService(login.User);
                    Application.Run(new MainForm());
                }

                try
                {
                    sender.SendGoodbye();
                }
                catch { }
                //}
            }
        }



        private static RequestSender InitTcpSender(Settings settings)
        {
            string ip = settings.SERVER_IP;
            TcpSender tcpClient;
            try
            {
                tcpClient = new TcpSender(ip, settings.CONTROL_TCP_PORT,
                    settings.RESPOND_TIMEOUT);
            }
            catch
            {
                MessageBox.Show("Nepodařilo se zinicializovat síťovou komunikaci, program bude ukončen.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            var sender = new RequestSender(tcpClient);
            sender.NetProblem += ProgramError;
            sender.UnrecognizedResponse += ProgramError;
            sender.CryptoError += ProgramError;
            sender.Unauthorized += ProgramError;
            sender.AccessDenied += ProgramError;
            sender.CannotExecute += ProgramError;
            sender.InvalidResponse += ProgramError;

            MasterContainer.AddService(sender);

            return sender;
        }



        private static RsaCrpyter GetServerKey(Settings settings, RequestSender sender)
        {
            string storeFile = settings.FINGERPRINT_STORE_FILE;
            var store = new FingerprintStore(storeFile);

            var hello = new HelloRequest();
            var helloResponse = sender.SendAndRecieve<HelloResponse>(hello);
            if (helloResponse == null)
            {
                MessageBox.Show("Server neodpověděl na požadavek pro zaslání veřejného klíče. Zkontrolujte síťové připojení.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var assymetricCrypter = new RsaCrpyter(helloResponse.CrypterConfig);
            if (!store.IsKnownFingerprint(assymetricCrypter.KeyFingerprint))
            {
                string msg = string.Format("Server se představil veřejným klíčem\r\n{0}\r\nkterý zatím není v seznamu známých hostitelů. Pokud tomuto serveru důvěřujete, přejete si klíč do seznamu přidat?", store.PrintFingerprint(assymetricCrypter.KeyFingerprint));

                var result = MessageBox.Show(msg, "Upozornění", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                    store.AddFingerPrint(assymetricCrypter.KeyFingerprint);
                else
                    return null;
            }

            return assymetricCrypter;
        }


        private static bool ExchangeKey(RequestSender sender)
        {
            var sessionCrypter = new AesCrypter();
            sender.SessionCrypter = sessionCrypter;
            MasterContainer.AddService<EncryptionProvider>(sessionCrypter);
            var keyExchange = new KeyExchangeRequest(sessionCrypter.Key);
            var keyExchangeResponse = sender.SendAndRecieve<Response>(keyExchange);
            if (keyExchangeResponse == null)
            {
                MessageBox.Show("Server neodpověděl na požadavek pro výměnu symetrického klíče. Zkontrolujte síťové připojení.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!keyExchangeResponse.Success)
            {
                MessageBox.Show("Nepodařilo se provést výměnu šifrovacího klíče se serverm. Spojení není bezpečné. Program bude ukončen.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }

            return true;
        }



        private static void ProgramError(Request request, Exception ex)
        {
            string message = (ex == null) ? "V programu došlo k neblíže specifikované chybě." : string.Format("V programu došlo k následující chybě:\r\n {0}", ex.Message);
            if (request != null)
                message += string.Format("\r\nPři odesílání požadavku {0}.", request.ToString());
            MessageBox.Show(message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
