using System;


[Serializable]
public class PlanBroadcastRequest : Request
{
    public override Permission[] RequiredPermissions
    {
        get
        {
            return new[] { Permission.PlanBroadcasts };
        }
    }
    public BroadcastInfo Broadcast { get; private set; }




    public override Response Execute()
    {
        var db = MasterContainer.GetService<IBroadcastDatabase>();
        var collisions = db.GetInterval(Broadcast.StartTime, Broadcast.EndTime);

        PlanBroadcastResult result;
        if (collisions.Length > 0)
        {
            var authorizator = MasterContainer.GetService<IAuthorizator>();
            // If there is a collission, admin can override it
            if (authorizator.HasPermission(User, Permission.AdminBroadcasts))
                result = PlanBroadcastResult.CanUploadIfAdmin;
            else
                result = PlanBroadcastResult.CannotUpload;
        }
        else
            result = PlanBroadcastResult.CanUpload;

        return new PlanBroadcastResponse(result, collisions);
    }



    public PlanBroadcastRequest(User user, BroadcastInfo broadcast) : base(user)
    {
        Broadcast = broadcast;
    }
}