using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using AbpCoreMvcIdentiyServer.EntityFrameworkCore.Seed;

namespace AbpCoreMvcIdentiyServer.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpCoreMvcIdentiyServerCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class AbpCoreMvcIdentiyServerEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<AbpCoreMvcIdentiyServerDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        AbpCoreMvcIdentiyServerDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        AbpCoreMvcIdentiyServerDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpCoreMvcIdentiyServerEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
