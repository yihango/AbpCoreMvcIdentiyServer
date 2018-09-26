using Abp.AspNetCore.Mvc.ViewComponents;

namespace AbpCoreMvcIdentiyServer.Web.Views
{
    public abstract class AbpCoreMvcIdentiyServerViewComponent : AbpViewComponent
    {
        protected AbpCoreMvcIdentiyServerViewComponent()
        {
            LocalizationSourceName = AbpCoreMvcIdentiyServerConsts.LocalizationSourceName;
        }
    }
}
