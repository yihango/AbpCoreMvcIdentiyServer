using System.Threading.Tasks;
using AbpCoreMvcIdentiyServer.Configuration.Dto;

namespace AbpCoreMvcIdentiyServer.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
