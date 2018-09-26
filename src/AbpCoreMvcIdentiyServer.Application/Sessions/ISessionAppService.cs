using System.Threading.Tasks;
using Abp.Application.Services;
using AbpCoreMvcIdentiyServer.Sessions.Dto;

namespace AbpCoreMvcIdentiyServer.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
