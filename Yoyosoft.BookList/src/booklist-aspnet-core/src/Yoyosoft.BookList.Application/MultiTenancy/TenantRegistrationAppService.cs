using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Extensions;
using Abp.MultiTenancy;
using Abp.Runtime.Security;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Identity;
using Yoyosoft.BookList.Authorization.Roles;
using Yoyosoft.BookList.Authorization.Users;
using Yoyosoft.BookList.Editions;
using Yoyosoft.BookList.MultiTenancy.Dto;
using StringExtensions = Abp.Extensions.StringExtensions;

namespace Yoyosoft.BookList.MultiTenancy
{
    public class TenantRegistrationAppService: BookListAppServiceBase, ITenantRegistrationAppService
    {
        private readonly EditionManager _editionManager;
        private readonly RoleManager _roleManager;
        private readonly IAbpZeroDbMigrator _abpZeroDbMigrator;
        private readonly IPasswordHasher<User> _passwordHasher;

        public TenantRegistrationAppService(EditionManager editionManager, RoleManager roleManager,
            IAbpZeroDbMigrator abpZeroDbMigrator, IPasswordHasher<User> passwordHasher)
        {
            _editionManager = editionManager;
            _roleManager = roleManager;
            _abpZeroDbMigrator = abpZeroDbMigrator;
            _passwordHasher = passwordHasher;
        }


        public async Task<TenantDto> RegisterTenant(CreateTenantDto input)
        {

            var tenant = new Tenant(input.TenancyName, input.Name)
            {
                IsActive = true
            };

            //连接字符串加密
            tenant.ConnectionString = input.ConnectionString.IsNullOrEmpty()
                ? null
                : SimpleStringCipher.Instance.Encrypt(input.ConnectionString);

            var defaultEdition = await _editionManager.FindByNameAsync(EditionManager.DefaultEditionName);
            if (defaultEdition!=null)
            {
                tenant.EditionId = defaultEdition.Id;
            }
            //创建租户信息
            await TenantManager.CreateAsync(tenant);
            await CurrentUnitOfWork.SaveChangesAsync();
            //初始化数据信息迁移
            _abpZeroDbMigrator.CreateOrMigrateForTenant(tenant);

            using (CurrentUnitOfWork.SetTenantId(tenant.Id))
            {
                CheckErrors(await _roleManager.CreateStaticRoles(tenant.Id));
                await CurrentUnitOfWork.SaveChangesAsync();

                var adminRole = _roleManager.Roles.Single(a => a.Name == StaticRoleNames.Tenants.Admin);

                await _roleManager.GrantAllPermissionsAsync(adminRole);
                var adminUser = User.CreateTenantAdminUser(tenant.Id, input.AdminEmailAddress);

                adminUser.Password = _passwordHasher.HashPassword(adminUser,
                    input.Password.IsNullOrWhiteSpace() ? User.DefaultPassword : input.Password);

                CheckErrors(await UserManager.CreateAsync(adminUser));
                await CurrentUnitOfWork.SaveChangesAsync();
                CheckErrors(await UserManager.AddToRoleAsync(adminUser, adminRole.Name));
                await CurrentUnitOfWork.SaveChangesAsync();

            }

            return tenant.MapTo<TenantDto>();
        }
    }
}