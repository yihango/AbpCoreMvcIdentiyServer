using System.Collections.Generic;
using AbpCoreMvcIdentiyServer.Roles.Dto;
using AbpCoreMvcIdentiyServer.Users.Dto;

namespace AbpCoreMvcIdentiyServer.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
