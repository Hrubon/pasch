public class DummyAuthenticator : IAuthenticator
{
    public string ConnectedServer
    {
        get
        {
            return "dummy";
        }
    }



    public AuthenticationResult Authenticate(User user, string password)
    {
        return AuthenticationResult.Granted;
    }
}