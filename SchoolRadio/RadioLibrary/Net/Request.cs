using System;


[Serializable]
public abstract class Request
{
    public virtual bool RequiresAuthentication
    {
        get
        {
            return true;
        }
    }
    public virtual bool RequiresAuthorization
    {
        get
        {
            return true;
        }
    }
    public virtual Permission[] RequiredPermissions
    {
        get
        {
            return new Permission[0];
        }
    }
    public User User { get; protected set; }
    public Session Session { get; set; }



    public abstract Response Execute();


    public bool MatchesPermissions(Permission[] permissions)
    {
        // TODO better hash implementation
        foreach (Permission required in RequiredPermissions)
        {
            bool found = false;
            foreach (Permission permission in permissions)
            {
                if (required == permission)
                {
                    found = true;
                    break;
                }
            }
            if (!found)
                return false;
        }
        return true;
    }



    public Request(User user)
    {
        User = user;
    }
}