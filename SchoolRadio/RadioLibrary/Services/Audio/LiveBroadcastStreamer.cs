using System.Net;
using System.Net.Sockets;

using NAudio.Wave;


public class LiveBroadcastStreamer
{
    IAudioCodec audioCodec;
    IPEndPoint serverEndpoint;
    UdpClient udpSender;



    public bool Streaming { get; private set; }
    public int InputDeviceNumber { get; set; }



    public void StartStreaming()
    {
        udpSender = new UdpClient();
        udpSender.Connect(serverEndpoint);
        Streaming = true;
    }


    public void StopStreaming()
    {
        if (Streaming)
        {
            Streaming = false;
            udpSender.Close();
        }
    }



    public void waveIn_DataAvailable(object sender, WaveInEventArgs e)
    {
        byte[] encodedData = audioCodec.Encode(e.Buffer, 0, e.BytesRecorded);
        udpSender.Send(encodedData, encodedData.Length);
    }



    public LiveBroadcastStreamer(string serverIp, int port, IAudioCodec audioCodec)
    {
        serverEndpoint = new IPEndPoint(IPAddress.Parse(serverIp), port);
        this.audioCodec = audioCodec;
    }
}