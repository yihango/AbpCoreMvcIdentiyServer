using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using AbpCoreMvcIdentiyServer.Configuration;
using AbpCoreMvcIdentiyServer.Web;

namespace AbpCoreMvcIdentiyServer.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AbpCoreMvcIdentiyServerDbContextFactory : IDesignTimeDbContextFactory<AbpCoreMvcIdentiyServerDbContext>
    {
        public AbpCoreMvcIdentiyServerDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AbpCoreMvcIdentiyServerDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AbpCoreMvcIdentiyServerDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AbpCoreMvcIdentiyServerConsts.ConnectionStringName));

            return new AbpCoreMvcIdentiyServerDbContext(builder.Options);
        }
    }
}
