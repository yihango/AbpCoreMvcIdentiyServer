using System.Collections.Generic;
using AbpCoreMvcIdentiyServer.Roles.Dto;

namespace AbpCoreMvcIdentiyServer.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
