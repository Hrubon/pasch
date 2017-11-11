public interface IAuthenticator
{
    AuthenticationResult Authenticate(User user, string password);
}