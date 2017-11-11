using System;
using System.Runtime.InteropServices;
using System.Security;


[Serializable]
public class User
{
    public static readonly User None = new User("", new byte[0]);



    public string Username { get; private set; }
    public byte[] PasswordEnc { get; private set; }



    public override bool Equals(object obj)
    {
        if (obj is User)
        {
            User other = (User)obj;
            return (Username == other.Username);
        }
        else
            return false;
    }


    public override int GetHashCode()
    {
        return Username.GetHashCode();
    }



    public User(string username, byte[] passwordEnc)
    {
        Username = username;
        PasswordEnc = passwordEnc;
    }
}