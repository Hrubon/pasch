using System;
using System.Net;


[Serializable]
public class LiveBroadcastRequest : Request
{
    public override Permission[] RequiredPermissions { get { return new[] { Permission.LiveBroadcast }; } }

    public string RemoteIP { get; private set; }
    public int Port { get; private set; }
    //public IAudioCodec Codec { get; private set; }



    public override Response Execute()
    {
        var playback = MasterContainer.GetService<Playback>();
        var reciever = new LiveBroadcastReciever(RemoteIP, Port, new PcmCodec(), playback);
        MasterContainer.AddService(reciever);
        try
        {
            reciever.RecieveLiveBroadcast();
            return new LiveBroadcastResponse(LiveBroadcastResults.Recieving);
        }
        catch (Exception ex)
        {
            reciever.Abort();
            return new LiveBroadcastResponse(LiveBroadcastResults.Failed, ex.Message);
        }
    }



    public LiveBroadcastRequest(User user, string remoteIP, int port) : base(user)
    {
        RemoteIP = remoteIP;
        Port = port;
        //Codec = codec;
    }
}