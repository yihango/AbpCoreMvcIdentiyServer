using Abp.AutoMapper;
using AbpCoreMvcIdentiyServer.Sessions.Dto;

namespace AbpCoreMvcIdentiyServer.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
