using Abp.Authorization;
using AbpCoreMvcIdentiyServer.Authorization.Roles;
using AbpCoreMvcIdentiyServer.Authorization.Users;

namespace AbpCoreMvcIdentiyServer.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
