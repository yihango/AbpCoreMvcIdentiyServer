using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpCoreMvcIdentiyServer.Configuration;

namespace AbpCoreMvcIdentiyServer.Web.Host.Startup
{
    [DependsOn(
       typeof(AbpCoreMvcIdentiyServerWebCoreModule))]
    public class AbpCoreMvcIdentiyServerWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AbpCoreMvcIdentiyServerWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpCoreMvcIdentiyServerWebHostModule).GetAssembly());
        }
    }
}
