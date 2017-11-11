using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

 
public class FileStreamer
{
    string fileName;
    int bufferSize;
    FileStream file;
    IPEndPoint serverEp;
    Thread streamerLoop;



    public void Start()
    {
        file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        streamerLoop.Start();
    }


    private void Stream()
    {
        TcpClient client = new TcpClient(serverEp.Address.ToString(), serverEp.Port);
        client.SendBufferSize = bufferSize;
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[bufferSize];
        while (true)
        {
            int count = file.Read(buffer, 0, buffer.Length);
            if (count == 0)
                break;

            stream.Write(buffer, 0, count);
        }
        file.Close();
        stream.Close();
        client.Close();
    }



    public FileStreamer(string fileName, int bufferSize, string ipAddress, int port)
    {
        this.fileName = fileName;
        this.bufferSize = bufferSize;
        serverEp = new IPEndPoint(IPAddress.Parse(ipAddress), port);
        streamerLoop = new Thread(Stream);
    }
}