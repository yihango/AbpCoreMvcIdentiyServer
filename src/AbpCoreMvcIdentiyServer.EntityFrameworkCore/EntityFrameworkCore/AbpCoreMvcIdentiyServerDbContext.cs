using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AbpCoreMvcIdentiyServer.Authorization.Roles;
using AbpCoreMvcIdentiyServer.Authorization.Users;
using AbpCoreMvcIdentiyServer.MultiTenancy;
using Abp.IdentityServer4;

namespace AbpCoreMvcIdentiyServer.EntityFrameworkCore
{
    public class AbpCoreMvcIdentiyServerDbContext : AbpZeroDbContext<Tenant, Role, User, AbpCoreMvcIdentiyServerDbContext>, IAbpPersistedGrantDbContext
    {
        /* Define a DbSet for each entity of the application */

        // TODO:abp zero identityServer4 实体
        public DbSet<PersistedGrantEntity> PersistedGrants { get; set; }


        public AbpCoreMvcIdentiyServerDbContext(DbContextOptions<AbpCoreMvcIdentiyServerDbContext> options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TODO:abp zero identityServer4 实体配置
            modelBuilder.ConfigurePersistedGrantEntity();
        }
    }
}
