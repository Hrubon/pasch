public class DummyAuthorizator : IAuthorizator
{
    public string ConnectedServer
    {
        get
        {
            return "dummy";
        }
    }



    public bool HasPermission(User user, Permission permission)
    {
        return true;
    }


    public Permission[] ListPermissions(User user)
    {
        return new[] { Permission.ReadBroadcasts,
                       Permission.ReadPermissions,
                       Permission.PlanBroadcasts,
                       Permission.LiveBroadcast,
                       Permission.AdminBroadcasts };
    }
}