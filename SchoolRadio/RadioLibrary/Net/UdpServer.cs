using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;


public class UdpServer
{
    Thread listeningLoop;
    bool stopListening;

    UdpClient server;
    IPEndPoint acceptingEndpoint;



    public int Port { get; private set; }



    public delegate void DataRecievedEventHandler(byte[] data);
    public event DataRecievedEventHandler DataRecieved;



    private void Listen()
    {
        byte[] buffer;

        while (!stopListening)
        {
            if (server.Available > 0)
            {
                buffer = server.Receive(ref acceptingEndpoint);
                if (DataRecieved != null)
                {
                    DataRecieved(buffer);
                }
            }
        }

        stopListening = false;
    }



    public void StartListening()
    {
        server = new UdpClient(Port);
        acceptingEndpoint = new IPEndPoint(IPAddress.Any, Port);
        listeningLoop.Start();
    }


    public void StopListening()
    {
        stopListening = true;
    }


    public void Respond(byte[] buffer)
    {
        if (acceptingEndpoint.Address != IPAddress.Any)
        {
            server.Send(buffer, buffer.Length, acceptingEndpoint);
        }
        else
            // Cannot respond to anycast. No connection has been estabilished yet. Server is in listening state.
            throw new SocketException((int)SocketError.DestinationAddressRequired);
    }



    public UdpServer(int port)
    {
        listeningLoop = new Thread(Listen);
        Port = port;
    }
}