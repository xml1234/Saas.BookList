

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using Yoyosoft.BookList.Authorization;

namespace Yoyosoft.BookList.BookListManagement.CloludBookLists.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="CloludBookListPermissions" /> for all permission names. CloludBookList
    ///</summary>
    public class CloludBookListAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public CloludBookListAuthorizationProvider()
		{

		}

        public CloludBookListAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public CloludBookListAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// 在这里配置了CloludBookList 的权限。
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(CloludBookListPermissions.Node , L("CloludBookList"));
			entityPermission.CreateChildPermission(CloludBookListPermissions.Query, L("QueryCloludBookList"));
			entityPermission.CreateChildPermission(CloludBookListPermissions.Create, L("CreateCloludBookList"));
			entityPermission.CreateChildPermission(CloludBookListPermissions.Edit, L("EditCloludBookList"));
			entityPermission.CreateChildPermission(CloludBookListPermissions.Delete, L("DeleteCloludBookList"));
			entityPermission.CreateChildPermission(CloludBookListPermissions.BatchDelete, L("BatchDeleteCloludBookList"));
			entityPermission.CreateChildPermission(CloludBookListPermissions.ExportExcel, L("ExportExcelCloludBookList"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, BookListConsts.LocalizationSourceName);
		}
    }
}