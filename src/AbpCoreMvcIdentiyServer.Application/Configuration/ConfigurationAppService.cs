using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AbpCoreMvcIdentiyServer.Configuration.Dto;

namespace AbpCoreMvcIdentiyServer.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AbpCoreMvcIdentiyServerAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
