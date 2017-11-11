using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using NAudio;
using NAudio.Wave;


class LiveBroadcastReciever
{
    Thread broadcastLoop;
    UdpClient udpReciever;
    IPEndPoint acceptingEndpoint;
    IAudioCodec audioCodec;
    BufferedWaveProvider buffer;
    Playback playback;



    public bool Connected { get; private set; }
    public string RemoteIP { get; private set; }



    public void RecieveLiveBroadcast()
    {
        udpReciever = new UdpClient(acceptingEndpoint.Port);
        Connected = true;

        ProgramOutput.Info("Live channel with client {0}:{1} established, broadcasting...", RemoteIP, acceptingEndpoint.Port);

        playback.Start(buffer);

        broadcastLoop.Start();
    }


    public void Abort()
    {
        if (Connected)
        {
            Connected = false;

            udpReciever.Close();
        }
    }



    private void Broadcast()
    {
        try
        {
            Thread.Sleep(300);
            while (Connected)
            {
                //if (!EndpointMatches(udpReciever.Client.RemoteEndPoint))
                //    throw new Exception("Endpoint does not match the client.");

                byte[] data = udpReciever.Receive(ref acceptingEndpoint);
                byte[] decodedData = audioCodec.Decode(data, 0, data.Length);
                buffer.AddSamples(decodedData, 0, decodedData.Length);
            }
        }
        catch (SocketException)
        {
            // usually not a problem - just means we have disconnected
        }
    }


    private bool EndpointMatches(EndPoint ep)
    {
        var ip = (IPEndPoint)ep;
        return (ip.Address.ToString() == RemoteIP);
    }



    public LiveBroadcastReciever(string ipAddress, int port, IAudioCodec audioCodec, Playback playback)
    {
        RemoteIP = ipAddress;
        broadcastLoop = new Thread(Broadcast);
        acceptingEndpoint = new IPEndPoint(IPAddress.Any, port);
        this.audioCodec = audioCodec;
        buffer = new BufferedWaveProvider(this.audioCodec.RecordFormat);
        this.playback = playback;
    }
}