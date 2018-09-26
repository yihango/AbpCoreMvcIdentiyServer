using System.Collections.Generic;
using AbpCoreMvcIdentiyServer.Roles.Dto;

namespace AbpCoreMvcIdentiyServer.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}