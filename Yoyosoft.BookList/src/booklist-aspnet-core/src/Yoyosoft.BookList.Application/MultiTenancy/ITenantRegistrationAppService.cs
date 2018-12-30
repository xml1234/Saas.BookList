using System.Threading.Tasks;
using Abp.Application.Services;
using Yoyosoft.BookList.MultiTenancy.Dto;

namespace Yoyosoft.BookList.MultiTenancy
{
    public interface ITenantRegistrationAppService:IApplicationService
    {
        /// <summary>
        /// 公开注册租户功能
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<TenantDto> RegisterTenant(CreateTenantDto input);
    }
}