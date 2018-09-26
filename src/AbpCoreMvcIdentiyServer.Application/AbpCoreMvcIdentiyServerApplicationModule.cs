using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AbpCoreMvcIdentiyServer.Authorization;

namespace AbpCoreMvcIdentiyServer
{
    [DependsOn(
        typeof(AbpCoreMvcIdentiyServerCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AbpCoreMvcIdentiyServerApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AbpCoreMvcIdentiyServerAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AbpCoreMvcIdentiyServerApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
