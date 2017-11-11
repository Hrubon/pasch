using System;
using System.Collections.Generic;


[Serializable]
public class ListPermissionsRequset : Request
{
    public override Permission[] RequiredPermissions
    {
        get
        {
            return new[] { Permission.ReadPermissions };
        }
    }

    public Permission[] RequestedPermissons { get; private set; }



    public override Response Execute()
    {
        var authorizator = MasterContainer.GetService<IAuthorizator>();
        var granted = new List<Permission>();
        foreach (Permission requested in RequestedPermissons)
        {
            if (authorizator.HasPermission(User, requested))
                granted.Add(requested);
        }

        return new ListPermissionsResponse(granted.ToArray());
    }



    public ListPermissionsRequset(User user, Permission[] requestedPermissions) : base(user)
    {
        RequestedPermissons = requestedPermissions;
    }
}