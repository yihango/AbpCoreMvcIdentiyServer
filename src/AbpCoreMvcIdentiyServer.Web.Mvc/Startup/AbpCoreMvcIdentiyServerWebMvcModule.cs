using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpCoreMvcIdentiyServer.Configuration;

namespace AbpCoreMvcIdentiyServer.Web.Startup
{
    [DependsOn(typeof(AbpCoreMvcIdentiyServerWebCoreModule))]
    public class AbpCoreMvcIdentiyServerWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AbpCoreMvcIdentiyServerWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<AbpCoreMvcIdentiyServerNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpCoreMvcIdentiyServerWebMvcModule).GetAssembly());
        }
    }
}
