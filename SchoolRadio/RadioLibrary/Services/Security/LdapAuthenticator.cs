using System.DirectoryServices.AccountManagement;
using System.Runtime.InteropServices;


public class LdapAuthenticator : IAuthenticator
{
    string domain;
    PrincipalContext ldap;



    public string ConnectedServer
    {
        get
        {
            return ldap.ConnectedServer;
        }
    }



    private string GetFullname(string username)
    {
        return string.Format("{0}@{1}", username, domain);
    }



    public AuthenticationResult Authenticate(User user, string password)
    {
        string fullname = GetFullname(user.Username);
        ProgramOutput.Info("Authenticating user {0} against LDAP...", fullname);
        var success = ldap.ValidateCredentials(fullname, password);

        return (success ? AuthenticationResult.Granted : AuthenticationResult.Denied);
    }



    public LdapAuthenticator(string domain, string user, string password)
    {
        this.domain = domain;
        string fullname = GetFullname(user);
        ldap = new PrincipalContext(ContextType.Domain, domain, fullname, password);
    }


    public void Connect()
    {
        try
        {
            var server = ldap.ConnectedServer;
        }
        catch
        {
            throw;
        }
    }


    public LdapAuthenticator(LdapCredentials creds)
    {
        domain = creds.Domain;
        string fullname = GetFullname(creds.Username);
        if (creds.OU == null)
            ldap = new PrincipalContext(ContextType.Domain, domain, fullname, creds.Password);
        else
            ldap = new PrincipalContext(ContextType.Domain, domain, creds.OU, fullname, creds.Password);
    }
}
