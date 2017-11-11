using System;
using System.Net.Sockets;
using System.Security.Cryptography;


public class RequestSender
{
    TcpSender client;
    NetFormatter formatter;



    public RsaCrpyter AsymetricCrypter { get; set; }
    public AesCrypter SessionCrypter { get; set; }



    public event RequestFailedHandler NetProblem;
    public event RequestFailedHandler UnrecognizedResponse;
    public event RequestFailedHandler CryptoError;
    public event RequestFailedHandler Unauthorized;
    public event RequestFailedHandler AccessDenied;
    public event RequestFailedHandler CannotExecute;
    public event RequestFailedHandler InvalidResponse;



    private byte[] EncryptRequest(Request request, EncryptionProvider crypter)
    {
        try
        {
            byte[] requestData = formatter.Format(request);
            return crypter.Encrypt(requestData);
        }
        catch (CryptographicException ex)
        {
            if (CryptoError != null)
                CryptoError(request, ex);

            return null;
        }
    }


    private byte[] DecryptResponse(byte[] responseData, EncryptionProvider crypter)
    {
        try
        {
            return crypter.Decrypt(responseData);
        }
        catch (CryptographicException ex)
        {
            if (CryptoError != null)
                CryptoError(null, ex);

            return null;
        }
    }



    public void SendGoodbye()
    {
        var user = MasterContainer.GetService<User>();
        var goodbye = new GoodbyeRequest(user);
        var requestData = EncryptRequest(goodbye, SessionCrypter);
        client.Send(requestData);
    }


    public RT SendAndRecieve<RT>(Request request) where RT : Response
    {
        // Serialize and encrypt request
        byte[] requestData = null;
        if (request is HelloRequest)
        {
            requestData = formatter.Format(request);
        }
        else if (request is KeyExchangeRequest)
        {
            requestData = EncryptRequest(request, AsymetricCrypter);
        }
        else
        {
            requestData = EncryptRequest(request, SessionCrypter);
        }

        // Send request and wait for response
        byte[] responseData = null;
        try
        {
            responseData = client.SendAndGetRespond(requestData);
            if (responseData == null)
            {
                if (NetProblem != null)
                    NetProblem(request);
                return null;
            }
        }
        catch (SocketException ex)
        {
            if (NetProblem != null)
                NetProblem(request, ex);
            return null;
        }

        // Decrpypt response
        if (!(request is HelloRequest || request is KeyExchangeRequest))
        {
            responseData = DecryptResponse(responseData, SessionCrypter);
        }
        if (responseData == null) return null;

        // Deserialize response
        Response response = null;
        try
        {
            response = formatter.GetResponse(responseData);
        }
        catch (Exception ex)
        {
            if (UnrecognizedResponse != null)
                UnrecognizedResponse(request, ex);
            return null;
        }


        if (response is UnauthorizedResponse)
        {
            if (Unauthorized != null)
                Unauthorized(request);
            return null;
        }
        else if (response is AccessDeniedResponse)
        {
            if (AccessDenied != null)
                AccessDenied(request);
            return null;
        }
        else if (response is CannotExecuteResponse)
        {
            if (CannotExecute != null)
                CannotExecute(request, (response as CannotExecuteResponse).Exception);
            return null;
        }
        else
        {
            try
            {
                return (RT)response;
            }
            catch (InvalidCastException ex)
            {
                if (InvalidResponse != null)
                    InvalidResponse(request, ex);
                return null;
            }
        }
    }


    public RequestSender(TcpSender client)
    {
        this.client = client;
        formatter = new NetFormatter();
    }
}