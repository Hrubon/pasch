using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;


public class LdapAuthorizator : IAuthorizator
{
    public const string LDAP_GROUP_ATTRIBUTE = "ldap_sam_account_name";



    string domain;
    PrincipalContext ldap;



    public string ConnectedServer
    {
        get
        {
            return ldap.ConnectedServer;
        }
    }
    public bool DefaultRight { get; set; } = false;



    private string GetFullname(string username)
    {
        return string.Format("{0}@{1}", username, domain);
    }


    private UserPrincipal FindPrincipal(User user)
    {
        return UserPrincipal.FindByIdentity(ldap, IdentityType.UserPrincipalName, user.Username);
    }


    private string[] GetGroupNames(IEnumerable<Principal> groups)
    {
        var names = new List<string>();
        foreach (var group in groups)
        {
            names.Add(group.SamAccountName);
        }

        return names.ToArray();
    }



    public bool HasPermission(User user, Permission permission)
    {
        permission = Permission.GetByName(permission.Name);

        var principal = FindPrincipal(user);
        if (principal == null)
            return false;

        if (!permission.Attributes.ContainsKey(LDAP_GROUP_ATTRIBUTE))
            return DefaultRight;

        string groupName = Convert.ToString(permission.Attributes[LDAP_GROUP_ATTRIBUTE]);

        foreach (var name in GetGroupNames(principal.GetGroups()))
        {
            if (name == groupName)
                return true;
        }

        return false;
    }


    public Permission[] ListPermissions(User user)
    {
        var watch = new Stopwatch();
        watch.Start();
        //
        var principal = FindPrincipal(user);
        //
        watch.Stop();
        ProgramOutput.Info("Got user from LDAP. It took: {0}s, {1}ms.", watch.Elapsed.Seconds, watch.ElapsedMilliseconds - watch.Elapsed.Seconds * 1000);

        if (principal == null)
            return new Permission[0];

        var permissions = new List<Permission>();

        watch.Reset();
        watch.Start();
        //
        var names = GetGroupNames(principal.GetGroups());
        //
        watch.Stop();
        ProgramOutput.Info("Got groups from LDAP. It took: {0}s, {1}ms.", watch.Elapsed.Seconds, watch.ElapsedMilliseconds - watch.Elapsed.Seconds * 1000);

        watch.Reset();
        watch.Start();
        //
        foreach (var permission in Permission.List)
        {
            if (!permission.Attributes.ContainsKey(LDAP_GROUP_ATTRIBUTE) && DefaultRight)
            {
                permissions.Add(permission);
                continue;
            }

            string groupName = Convert.ToString(permission.Attributes[LDAP_GROUP_ATTRIBUTE]);
            foreach (var name in names)
            {
                if (name == groupName)
                {
                    permissions.Add(permission);
                    break;
                }
            }
        }
        //
        watch.Stop();
        ProgramOutput.Info("Groups commited, authorization is finished. It took: {0}s, {1}ms.", watch.Elapsed.Seconds, watch.ElapsedMilliseconds - watch.Elapsed.Seconds * 1000);

        return permissions.ToArray();
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



    public LdapAuthorizator(string domain, string user, string password)
    {
        this.domain = domain;
        string fullname = GetFullname(user);
        ldap = new PrincipalContext(ContextType.Domain, domain, fullname, password);
    }


    public LdapAuthorizator(LdapCredentials creds)
    {
        domain = creds.Domain;
        string fullname = GetFullname(creds.Username);
        if (creds.OU == null)
            ldap = new PrincipalContext(ContextType.Domain, domain, fullname, creds.Password);
        else
            ldap = new PrincipalContext(ContextType.Domain, domain, creds.OU, fullname, creds.Password);
    }
}