using System;


[Serializable]
public class EditBroadcasRequest : Request
{
    public override Permission[] RequiredPermissions
    {
        get
        {
            return new[] { Permission.AdminBroadcasts };
        }
    }
    public int BroadcastId { get; private set; }
    public DateTime NewStartTime { get; private set; }
    public string NewLabel { get; private set; }



    public override Response Execute()
    {
        var db = MasterContainer.GetService<IBroadcastDatabase>();
        var altered = db.Edit(BroadcastId, NewStartTime, NewLabel);

        return new AlterBroadcastResponse(altered ? AlterBroadcastResult.Success : AlterBroadcastResult.NotFound);
    }



    public EditBroadcasRequest(User user, int broadcastId,  DateTime newStartTime, string newLabel) : base(user)
    {
        BroadcastId = broadcastId;
        NewStartTime = newStartTime;
        NewLabel = newLabel;
    }
}