using System;


[Serializable]
public class UnauthorizedResponse : Response
{
    public override int Code
    {
        get
        {
            return 101;
        }
    }

    public User User { get; private set; }



    public UnauthorizedResponse(User user)
    {
        User = user;
    }
}