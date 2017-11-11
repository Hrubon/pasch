using System;


[Serializable]
public class UploadBroadcastRequest : Request
{
    public override Permission[] RequiredPermissions
    {
        get
        {
            return new[] { Permission.PlanBroadcasts };
        }
    }
    public BroadcastInfo Broadcast { get; private set; }
    public MediaType Format { get; private set; }
    public int Port { get; private set; }
    public int BufferSize { get; private set; }



    public override Response Execute()
    {
        var db = MasterContainer.GetService<IBroadcastDatabase>();
        var collisions = db.GetInterval(Broadcast.StartTime, Broadcast.EndTime);

        UploadBroadcastResult result;
        if (collisions.Length > 0)
        {
            var authorizator = MasterContainer.GetService<IAuthorizator>();
            if (authorizator.HasPermission(User, Permission.AdminBroadcasts))
            {
                foreach (var collision in collisions)
                {
                    db.Remove(collision.Id);
                }
                result = UploadBroadcastResult.Success;
            }
            else
                result = UploadBroadcastResult.CollissionBlocked;
        }
        else
            result = UploadBroadcastResult.Success;

        if (result == UploadBroadcastResult.Success)
        {
            var store = MasterContainer.GetService<FileStore>();
            string fullPath = store.GenerateFullFilename(Broadcast);
            FileReciever reciever = new FileReciever(Session.Host, Port, BufferSize, fullPath);
            reciever.Start();

            Broadcast.Filename = store.GetFilename(Broadcast);
            db.Add(Broadcast);
        }

        return new UploadBroadcastResponse(result);
    }



    public UploadBroadcastRequest(User user, BroadcastInfo broadcast, MediaType format, int port, int bufferSize = 1024) : base(user)
    {
        Broadcast = broadcast;
        Format = format;
        Port = port;
        BufferSize = bufferSize;
    }
}