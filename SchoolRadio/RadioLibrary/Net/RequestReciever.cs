using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Security.Cryptography;


public class RequestReciever
{
    TcpServer server;
    SessionManager sessions;
    NetFormatter formatter;
    RsaCrpyter asymetricCrypter;
    IAuthenticator authenticator;
    IAuthorizator authorizator;



    public event RecieverError UnknownSession;
    public event RequestFailedHandler NetProblem;
    public event RequestFailedHandler UnrecognizedRequest;
    public event RequestFailedHandler ProtocolError;
    public event RequestFailedHandler CryptoError;
    public event RequestFailedHandler Unauthorized;
    public event RequestFailedHandler AccessDenied;
    public event RequestFailedHandler InvalidResponse;
    public event RequestFailedHandler ExecuteError;



    private R MatchRequest<R>(byte[] requestData) where R : Request
    {
        R request = null;
        try
        {
            request = (R)formatter.GetRequest(requestData);
        }
        catch (SerializationException ex)
        {
            if (UnrecognizedRequest != null)
                UnrecognizedRequest(null, ex);

            return request;
        }

        if (!(request is R))
        {
            if (ProtocolError != null)
                ProtocolError(request, new Exception("Expected other request in this phase."));
        }

        return request;
    }


    private byte[] DecryptRequest(byte[] requestData, EncryptionProvider crpyter)
    {
        try
        {
            return crpyter.Decrypt(requestData);
        }
        catch (CryptographicException ex)
        {
            if (CryptoError != null)
                CryptoError(null, ex);

            return null;
        }
    }


    private byte[] EncryptResponse(byte[] requestData, EncryptionProvider crpyter)
    {
        try
        {
            return crpyter.Encrypt(requestData);
        }
        catch (CryptographicException ex)
        {
            if (CryptoError != null)
                CryptoError(null, ex);

            return null;
        }
    }




    private void Server_ClientEstablishing(IPEndPoint ep)
    {
        string host = ep.Address.ToString();
        int port = ep.Port;
        sessions.AddSession(host, port);
    }


    private void Server_DataRecieved(string host, byte[] requestData)
    {
        // Match host session
        var session = sessions.GetSession(host);
        if (session == null)
        {
            if (UnknownSession != null)
                UnknownSession(string.Format("Session not found for host: {0}.", host));

            return;
        }

        // Commit request session phase
        Request request = null;
        if (session.CurrentPhase == SessionPhase.Hello)
        {
            request = MatchRequest<HelloRequest>(requestData);
            if (request == null) return;
        }
        else if (session.CurrentPhase == SessionPhase.Encryption)
        {
            var data = DecryptRequest(requestData, asymetricCrypter);
            if (data == null) return;

            request = MatchRequest<KeyExchangeRequest>(data);
        }
        else if (session.CurrentPhase == SessionPhase.Authentication)
        {
            var data = DecryptRequest(requestData, session.Crpter);
            if (data == null) return;

            request = MatchRequest<AuthenticateRequest>(data);
        }
        else
        {
            var data = DecryptRequest(requestData, session.Crpter);
            if (data == null) return;

            request = MatchRequest<Request>(data);
        }
        request.Session = session;

        Response response = null;

        // Authenitacate request user
        AuthenticationResult result = AuthenticationResult.Denied;
        if (request.RequiresAuthentication)
        {
            string password = session.Crpter.DecryptString(request.User.PasswordEnc);
            result = authenticator.Authenticate(request.User, password);
        }
        if (!request.RequiresAuthentication || result == AuthenticationResult.Granted)
        {
            // Check user permissions for request (authorize request user)
            Permission[] permissions = null;
            if (request.RequiresAuthorization)
                permissions = authorizator.ListPermissions(request.User);

            if (!request.RequiresAuthorization || request.MatchesPermissions(permissions))
            {
                try
                {
                    // EXECUTE REQUEST
                    ProgramOutput.Info("Executing request: {0}...", request.ToString());
                    response = request.Execute();
                }
                catch (Exception ex)
                {
                    response = new CannotExecuteResponse(ex);
                    if (ExecuteError != null)
                        ExecuteError(request, ex);
                }
            }
            else
            {
                response = new AccessDeniedResponse();
                if (AccessDenied != null)
                    AccessDenied(request);
            }
        }
        else if (result == AuthenticationResult.Denied)
        {
            response = new UnauthorizedResponse(request.User);
            if (Unauthorized != null)
                Unauthorized(request);
        }

        if (!(request is GoodbyeRequest))
        {
            // Serialize response
            byte[] responseData = null;
            try
            {
                responseData = formatter.Format(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (InvalidResponse != null)
                    InvalidResponse(request);
                return;
            }

            // Encrypt response
            if (session.CurrentPhase == SessionPhase.Authentication || session.CurrentPhase == SessionPhase.Established)
            {
                responseData = EncryptResponse(responseData, session.Crpter);
            }
            if (responseData == null) return;

            // Send response
            try
            {
                ProgramOutput.Info("Responding: {0}, status code: {1}", response, response.Code);
                server.SendMessage(host, responseData);
            }
            catch (SocketException)
            {
                if (NetProblem != null)
                    NetProblem(request);
                return;
            }

            session.NextPhase();
        }
    }



    public RequestReciever(TcpServer server, RsaCrpyter asymetricCrypter, IAuthenticator authenticator, IAuthorizator authorizator)
    {
        this.server = server;
        this.asymetricCrypter = asymetricCrypter;
        this.authenticator = authenticator;
        this.authorizator = authorizator;
        this.sessions = new SessionManager();
        this.formatter = new NetFormatter();
        server.ClientEstablishing += Server_ClientEstablishing;
        server.DataRecieved += Server_DataRecieved;
    }
}