using System;


[Serializable]
public class SelectBroadcastRequest : Request
{
    public override Permission[] RequiredPermissions
    {
        get
        {
            return new[] { Permission.ReadBroadcasts };
        }
    }
    public DateTime IntervalStart { get; private set; }
    public DateTime IntervalEnd { get; private set; }



    public override Response Execute()
    {
        var db = MasterContainer.GetService<IBroadcastDatabase>();
        var broadcasts = db.GetInterval(IntervalStart, IntervalEnd);
        return new SelectBroadcastResponse(broadcasts);
    }



    public SelectBroadcastRequest(User user, DateTime intervalStart, DateTime intervalEnd)
        : base(user)
    {
        IntervalStart = intervalStart;
        IntervalEnd = intervalEnd;
    }
}