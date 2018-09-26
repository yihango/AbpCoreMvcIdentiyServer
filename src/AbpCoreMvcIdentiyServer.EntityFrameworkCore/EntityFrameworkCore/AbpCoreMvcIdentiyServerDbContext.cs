using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AbpCoreMvcIdentiyServer.Authorization.Roles;
using AbpCoreMvcIdentiyServer.Authorization.Users;
using AbpCoreMvcIdentiyServer.MultiTenancy;

namespace AbpCoreMvcIdentiyServer.EntityFrameworkCore
{
    public class AbpCoreMvcIdentiyServerDbContext : AbpZeroDbContext<Tenant, Role, User, AbpCoreMvcIdentiyServerDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AbpCoreMvcIdentiyServerDbContext(DbContextOptions<AbpCoreMvcIdentiyServerDbContext> options)
            : base(options)
        {
        }
    }
}
