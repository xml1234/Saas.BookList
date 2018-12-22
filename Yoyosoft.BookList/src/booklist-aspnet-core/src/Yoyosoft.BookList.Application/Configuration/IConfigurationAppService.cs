using System.Threading.Tasks;
using Yoyosoft.BookList.Configuration.Dto;

namespace Yoyosoft.BookList.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
