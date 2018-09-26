using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpCoreMvcIdentiyServer.MultiTenancy.Dto;

namespace AbpCoreMvcIdentiyServer.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
