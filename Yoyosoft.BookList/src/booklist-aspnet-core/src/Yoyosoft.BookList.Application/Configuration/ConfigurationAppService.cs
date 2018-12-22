using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Yoyosoft.BookList.Configuration.Dto;

namespace Yoyosoft.BookList.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BookListAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
