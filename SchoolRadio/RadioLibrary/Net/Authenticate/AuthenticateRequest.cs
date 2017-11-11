using System;


[Serializable]
public class AuthenticateRequest : Request
{
    public override bool RequiresAuthentication
    {
        get
        {
            return false;
        }
    }
    public override bool RequiresAuthorization
    {
        get
        {
            return false;
        }
    }



    public override Response Execute()
    {
        var authenticator = MasterContainer.GetService<IAuthenticator>();
        string password = Session.Crpter.DecryptString(User.PasswordEnc);
        var result = authenticator.Authenticate(User, password);

        return new AuthenticateResponse(result);
    }
        

    public AuthenticateRequest(User user) : base(user)
    {
    }
}
