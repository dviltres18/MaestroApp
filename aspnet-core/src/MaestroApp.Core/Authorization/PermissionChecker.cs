using Abp.Authorization;
using MaestroApp.Authorization.Roles;
using MaestroApp.Authorization.Users;

namespace MaestroApp.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
