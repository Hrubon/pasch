public class LdapCredentials
{
    public string Username { get; private set; }
    public string Password { get; private set; }
    public string Domain { get; private set; }
    public string OU { get; private set; }



    public LdapCredentials(string username, string password, string domain, string ou = null)
    {
        Username = username;
        Password = password;
        Domain = domain;
        OU = ou;
    }
}