using System.Net;
using System.Net.Sockets;
using System.Threading;


public class UdpSender
{
    UdpClient client;
    IPEndPoint server;
    int respondTimeout;



    public void Send(byte[] buffer)
    {
        client.Connect(server);
        client.Send(buffer, buffer.Length);
    }


    public byte[] SendAndGetRespond(byte[] buffer)
    {
        Send(buffer);

        int counter = 0;
        while (counter < respondTimeout)
        {
            if (client.Available > 0)
            {
                byte[] data = client.Receive(ref server);
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
        client = new UdpClient();
        server = new IPEndPoint(IPAddress.Parse(serverIp), port);
    }



    public UdpSender(string serverIp, int port, int respondTimeout)
    {
        Init(serverIp, port);
        this.respondTimeout = respondTimeout;
    }
}