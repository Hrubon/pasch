using System;
using System.Collections.Generic;


[Serializable]
public class ListPermissionsResponse : Response
{
    private List<Permission> grantedPermissions;



    public override int Code { get { return 201; } }

    public Permission[] GrantedPermissions
    {
        get
        {
            return grantedPermissions.ToArray();
        }
    }



    public bool ContainsPermission(Permission permission)
    {
        return grantedPermissions.Contains(permission);
    }



    public ListPermissionsResponse(Permission[] grantedPermissions)
    {
        this.grantedPermissions = new List<Permission>(grantedPermissions);
    }
}