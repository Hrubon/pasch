using System;
using System.Collections.Generic;
using System.Linq;


[Serializable]
public class Permission
{
    public static readonly Permission ReadPermissions = new Permission(101, "ReadPermissions");
    public static readonly Permission ReadBroadcasts = new Permission(102, "ReadBroadcasts");
    public static readonly Permission PlanBroadcasts = new Permission(103, "PlanBroadcasts");
    public static readonly Permission AdminBroadcasts = new Permission(104, "AdminBroadcasts");
    public static readonly Permission LiveBroadcast = new Permission(105, "LiveBroadcast");



    private static Dictionary<string, Permission> permissions;



    private static Dictionary<string, Permission> GetPermissions()
    {
        var t = typeof(Permission);
        var permissions = t.GetFields().Where(
            (field) => field.IsPublic && field.IsStatic && field.IsInitOnly && field.FieldType == t);

        var dict = new Dictionary<string, Permission>();
        foreach (var permission in permissions)
        {
            var obj = (Permission)permission.GetValue(null);
            dict.Add(obj.Name, obj);
        }

        return dict;
    }



    public static IEnumerable<Permission> List
    {
        get
        {
            if (permissions == null)
                permissions = GetPermissions();

            return permissions.Values;
        }
    }


    public static Permission GetByName(string name)
    {
        if (permissions.ContainsKey(name))
            return permissions[name];

        return null;
    }



    public int Code { get; private set; }
    public string Name { get; private set; }
    public Dictionary<string, object> Attributes { get; private set; }



    public override int GetHashCode()
    {
        return this.Code;
    }

    public override bool Equals(object obj)
    {
        return (this.Code == ((Permission)obj).Code);
    }

    public static bool operator == (Permission p1, Permission p2)
    {
        return (p1.Code == p2.Code);
    }

    public static bool operator != (Permission p1, Permission p2)
    {
        return !(p1 == p2);
    }



    public Permission(int code, string name)
    {
        Code = code;
        Name = name;
        Attributes = new Dictionary<string, object>();
    }
}