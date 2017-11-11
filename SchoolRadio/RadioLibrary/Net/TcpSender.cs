using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;


public class TcpSender
{
    TcpClient client;
    IPEndPoint server;



    public int ResponseTimeout { get; private set; }



    public void Send(byte[] message)
    {
        if (!client.Connected)
            client.Connect(server);

        byte[] data = TcpProtocol.FrameMessage(message);

        var stream = client.GetStream();
        stream.Write(data, 0, data.Length);
    }


    public byte[] SendAndGetRespond(byte[] message)
    {
        Send(message);

        int counter = 0;
        var stream = client.GetStream();
        while (counter < ResponseTimeout)
        {
            if (client.Available > 0)
            {
                int len = TcpProtocol.GetLength(stream);

                byte[] data = new byte[len];
                using (var received = new MemoryStream())
                {
                    int total = 0;
                    while (total < len)
                    {
                        byte[] buffer = new byte[client.Available];
                        int read = stream.Read(buffer, 0, buffer.Length);
                        received.Write(buffer, 0, read);
                        total += read;
                    }
                    data = received.GetBuffer();
                }

                return data;
            }
            Thread.Sleep(1);
            counter++;
        }

        return null;
    }



    // When server IP settings is changed during runtime, call this method to take the effect.
    public void Init(string serverIp, int port)
    {
        client = new TcpClient();
        server = new IPEndPoint(IPAddress.Parse(serverIp), port);
    }


    public TcpSender(string serverIp, int port, int respondTimeout)
    {
        Init(serverIp, port);
        ResponseTimeout = respondTimeout;
    }
}