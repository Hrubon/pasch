using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


public class TcpServer
{
    TcpListener listener;
    Thread listenerLoop;
    Dictionary<string, Client> clients;
    bool stopListening;



    public delegate void ClientEstablishingEventHandler(IPEndPoint ep);
    public delegate void DataRecievedEventHandler(string host, byte[] data);

    public event ClientEstablishingEventHandler ClientEstablishing;
    public event DataRecievedEventHandler DataRecieved;
    public event Action OnStopListening;



    public int Port { get; private set; }
    public int ClientTimeout { get; private set; }
    public bool Listening
    {
        get
        {
            return !stopListening;
        }
    }



    private void Listen()
    {
        while (!stopListening)
        {
            var client = listener.AcceptTcpClient();
            var ep = (IPEndPoint)client.Client.RemoteEndPoint;
            string host = ep.Address.ToString();

            if (ClientEstablishing != null)
                ClientEstablishing(ep);

            var subthread = Task.Factory.StartNew(() => Fork(host, client));

            if (!clients.ContainsKey(host))
            {
                clients.Add(host, new Client(subthread, client));
            }
        }
    }


    private void Fork(string host, TcpClient client)
    {
        while (!stopListening && clients.ContainsKey(host))
        {
            if (client.Available >= 4)
            {
                var stream = client.GetStream(); 
                int len = TcpProtocol.GetLength(stream); // Use binary formatter to auto proccess whole incomming data.

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

                if (DataRecieved != null)
                    DataRecieved(host, data);
            }
        }
    }


    public void StartListening()
    {
        var acceptingEndpoint = new IPEndPoint(IPAddress.Any, Port);
        listener = new TcpListener(acceptingEndpoint);
        stopListening = false;
        listener.Start();
        listenerLoop.Start();
    }


    public void StopListening()
    {
        stopListening = true;

        if (OnStopListening != null)
            OnStopListening();

        foreach (var client in clients.Values)
        {
            client.Subthread.Wait(ClientTimeout);
        }
    }


    public void DisconnectClient(string host)
    {
        if (clients.ContainsKey(host))
        {
            clients[host].Subthread.Wait(100);
            clients[host].NetInterface.Close();
        }
        clients.Remove(host);
    }



    public void SendMessage(string host, byte[] message)
    {
        if (!clients.ContainsKey(host))
            throw new InvalidOperationException(string.Format("No such host ({0}) is connected to the server.", host));

        var framed = TcpProtocol.FrameMessage(message);

        var client = clients[host];
        client.NetInterface.Client.Send(framed);
    }


    public void SendMessageToAll(byte[] message)
    {
        foreach (var client in clients.Values)
        {
            var framed = TcpProtocol.FrameMessage(message);
            client.NetInterface.Client.Send(framed);
        }
    }



    public TcpServer(int port, int clientTimeout = 100)
    {
        listenerLoop = new Thread(Listen);
        Port = port;
        ClientTimeout = clientTimeout;
        clients = new Dictionary<string, Client>();
    }
}