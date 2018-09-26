using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace AbpCoreMvcIdentiyServer.Web.Views
{
    public abstract class AbpCoreMvcIdentiyServerRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected AbpCoreMvcIdentiyServerRazorPage()
        {
            LocalizationSourceName = AbpCoreMvcIdentiyServerConsts.LocalizationSourceName;
        }
    }
}
