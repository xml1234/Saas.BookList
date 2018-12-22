using Abp.MultiTenancy;
using Yoyosoft.BookList.Authorization.Users;

namespace Yoyosoft.BookList.MultiTenancy
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
