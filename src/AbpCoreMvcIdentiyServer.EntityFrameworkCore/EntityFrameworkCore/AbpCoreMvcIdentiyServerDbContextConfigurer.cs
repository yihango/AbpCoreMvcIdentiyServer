using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AbpCoreMvcIdentiyServer.EntityFrameworkCore
{
    public static class AbpCoreMvcIdentiyServerDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AbpCoreMvcIdentiyServerDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AbpCoreMvcIdentiyServerDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
