using System;


[Serializable]
public class RemoveBroadcasRequest : Request
{
    public override Permission[] RequiredPermissions
    {
        get
        {
            return new[] { Permission.AdminBroadcasts };
        }
    }
    public BroadcastInfo Broadcast { get; private set; }



    public override Response Execute()
    {
        var db = MasterContainer.GetService<IBroadcastDatabase>();
        var removed = db.Remove(Broadcast.Id);
        if (removed)
        {
            var store = MasterContainer.GetService<FileStore>();
            if (Broadcast.Filename != null)
                store.Delete(Broadcast.Filename);
        }

        return new AlterBroadcastResponse(removed? AlterBroadcastResult.Success : AlterBroadcastResult.NotFound);
    }



    public RemoveBroadcasRequest(User user, BroadcastInfo broadcast):base(user)
    {
        Broadcast = broadcast;
    }
}