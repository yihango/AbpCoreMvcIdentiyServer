using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AbpCoreMvcIdentiyServer.Controllers
{
    public abstract class AbpCoreMvcIdentiyServerControllerBase: AbpController
    {
        protected AbpCoreMvcIdentiyServerControllerBase()
        {
            LocalizationSourceName = AbpCoreMvcIdentiyServerConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
