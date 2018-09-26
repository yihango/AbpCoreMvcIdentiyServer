using System.Threading.Tasks;
using Abp.Application.Services;
using AbpCoreMvcIdentiyServer.Authorization.Accounts.Dto;

namespace AbpCoreMvcIdentiyServer.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
