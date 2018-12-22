

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using Yoyosoft.BookList.Authorization;

namespace Yoyosoft.BookList.BookListManagement.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="BookPermissions" /> for all permission names. Book
    ///</summary>
    public class BookAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public BookAuthorizationProvider()
		{

		}

        public BookAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public BookAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了Book 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(BookPermissions.Node , L("Book"));
			entityPermission.CreateChildPermission(BookPermissions.Query, L("QueryBook"));
			entityPermission.CreateChildPermission(BookPermissions.Create, L("CreateBook"));
			entityPermission.CreateChildPermission(BookPermissions.Edit, L("EditBook"));
			entityPermission.CreateChildPermission(BookPermissions.Delete, L("DeleteBook"));
			entityPermission.CreateChildPermission(BookPermissions.BatchDelete, L("BatchDeleteBook"));
			entityPermission.CreateChildPermission(BookPermissions.ExportExcel, L("ExportExcelBook"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, BookListConsts.LocalizationSourceName);
		}
    }
}