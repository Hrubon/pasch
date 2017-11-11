using System;
using System.Collections.Generic;


public class AuthorizatorCache : IAuthorizator
{
    private IAuthorizator realAuthorizator;
    private Dictionary<string, CacheEntry<Permission[]>> cache;



    public int CacheValidity { get; set; }



    private void RefreshIfNecessary(User user)
    {
        if (cache.ContainsKey(user.Username))
        {
            var entry = cache[user.Username];
            if (DateTime.Now.Subtract(entry.Timestamp).TotalSeconds < CacheValidity)
                return;
            else
                cache.Remove(user.Username);
        }

        var result = realAuthorizator.ListPermissions(user);
        var newEntry = new CacheEntry<Permission[]>(user, DateTime.Now, result);
        cache.Add(user.Username, newEntry);
    }



    public bool HasPermission(User user, Permission permission)
    {
        RefreshIfNecessary(user);
        foreach (Permission entry in cache[user.Username].Item)
        {
            if (entry == permission)
                return true;
        }
        return false;
    }


    public Permission[] ListPermissions(User user)
    {
        RefreshIfNecessary(user);
        return cache[user.Username].Item;
    }



    public AuthorizatorCache(IAuthorizator realAuthorizator, int cacheValidity)
    {
        this.realAuthorizator = realAuthorizator;
        CacheValidity = cacheValidity;

        cache = new Dictionary<string, CacheEntry<Permission[]>>();
    }
}