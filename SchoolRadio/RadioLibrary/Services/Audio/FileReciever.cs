using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;


public class FileReciever
{
    Thread listenLoop;
    IPEndPoint acceptingEndpoint;
    string outputPath;
    int bufferSize;
    FileStream outputFile;



    public void Start()
    {
        outputFile = new FileStream(outputPath, FileMode.Create);
        listenLoop.Start();
    }



    private bool EndpointMatches(EndPoint ep1, EndPoint ep2)
    {
        IPEndPoint ipEp1 = (IPEndPoint)ep1;
        IPEndPoint ipEp2 = (IPEndPoint)ep2;

        return (ipEp1.Address.ToString() == ipEp2.Address.ToString());
    }


    private void Listen()
    {
        TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Any, acceptingEndpoint.Port));
        listener.Start();
        TcpClient client = listener.AcceptTcpClient();
        client.ReceiveBufferSize = bufferSize;
        if (EndpointMatches(client.Client.RemoteEndPoint, acceptingEndpoint))
        {
            ProgramOutput.Info("Connection with client {0}:{1} established. Recieving audio data...", acceptingEndpoint.Address, acceptingEndpoint.Port);
            NetworkStream stream = client.GetStream();
            while (true)
            {
                byte[] buffer = new byte[bufferSize];
                int read = stream.Read(buffer, 0, buffer.Length);
                if (read == 0)
                    break;

                outputFile.Write(buffer, 0, read);
            }
            stream.Close();
        }
        else
        {
            throw new Exception("Endpoint does not match the client.");
        }
        outputFile.Close();
        client.Close();
        listener.Stop();
    }



    public FileReciever(string ipAddress, int port, int bufferSize, string outputPath)
    {
        listenLoop = new Thread(Listen);
        acceptingEndpoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
        this.outputPath = outputPath;
        this.bufferSize = bufferSize;
    }
}