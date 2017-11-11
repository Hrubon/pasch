using System;
using System.Collections.Generic;


public class AuthenticatorCache : IAuthenticator
{
    private IAuthenticator realAuthenticator;
    private Dictionary<string, CacheEntry<AuthenticationResult>> cache;



    public int CacheValidity { get; set; }



    public AuthenticationResult Authenticate(User user, string password)
    {
        if (cache.ContainsKey(user.Username))
        {
            var entry = cache[user.Username];
            if (DateTime.Now.Subtract(entry.Timestamp).TotalSeconds < CacheValidity)
                return entry.Item;
            else
                cache.Remove(user.Username);
        }

        var result = realAuthenticator.Authenticate(user, password);
        var newEntry = new CacheEntry<AuthenticationResult>(user, DateTime.Now, result);
        cache.Add(user.Username, newEntry);

        return result;
    }


    public AuthenticatorCache(IAuthenticator realAuthenticator, int cacheValidity)
    {
        this.realAuthenticator = realAuthenticator;
        cache = new Dictionary<string, CacheEntry<AuthenticationResult>>();

        CacheValidity = cacheValidity;
    }
}