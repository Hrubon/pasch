using System;


[Serializable]
public class GoodbyeRequest : Request
{
    public override Permission[] RequiredPermissions
    {
        get
        {
            return new Permission[0];
        }
    }



    public override Response Execute()
    {
        var server = MasterContainer.GetService<TcpServer>();
        var manager = MasterContainer.GetService<SessionManager>();
        server.DisconnectClient(Session.Host);
        manager.RemoveSession(Session);

        return new SuccessResponse();
    }



    public GoodbyeRequest(User user)
        : base(user)
    {
    }
}