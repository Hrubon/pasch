public interface IAuthorizator
{
    bool HasPermission(User user, Permission permission);
    Permission[] ListPermissions(User user);
}