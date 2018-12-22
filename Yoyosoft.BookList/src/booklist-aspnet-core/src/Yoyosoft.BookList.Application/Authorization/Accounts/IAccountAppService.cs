using System.Threading.Tasks;
using Abp.Application.Services;
using Yoyosoft.BookList.Authorization.Accounts.Dto;

namespace Yoyosoft.BookList.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
