using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Yoyosoft.BookList.MultiTenancy.Dto;

namespace Yoyosoft.BookList.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
