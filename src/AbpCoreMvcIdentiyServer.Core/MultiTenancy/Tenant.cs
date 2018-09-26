using Abp.MultiTenancy;
using AbpCoreMvcIdentiyServer.Authorization.Users;

namespace AbpCoreMvcIdentiyServer.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
