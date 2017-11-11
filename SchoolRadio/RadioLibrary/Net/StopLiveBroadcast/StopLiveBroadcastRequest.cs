using System;
using System.Net;


[Serializable]
public class StopLiveBroadcastRequest : Request
{
    public override Permission[] RequiredPermissions { get { return new[] { Permission.LiveBroadcast }; } }



    public override Response Execute()
    {
        try
        {
            var reciever = MasterContainer.GetService<LiveBroadcastReciever>();
            reciever.Abort();
            MasterContainer.RemoveService<LiveBroadcastReciever>();

            return new StopLiveBroadcastResponse(StopLiveBroadcastResults.Stopped);
        }
        catch
        {
            return new StopLiveBroadcastResponse(StopLiveBroadcastResults.NoBroadcast);
        }

    }



    public StopLiveBroadcastRequest(User user) : base(user)
    {
    }
}