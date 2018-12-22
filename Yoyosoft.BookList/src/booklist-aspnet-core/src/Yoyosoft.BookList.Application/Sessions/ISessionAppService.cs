using System.Threading.Tasks;
using Abp.Application.Services;
using Yoyosoft.BookList.Sessions.Dto;

namespace Yoyosoft.BookList.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
