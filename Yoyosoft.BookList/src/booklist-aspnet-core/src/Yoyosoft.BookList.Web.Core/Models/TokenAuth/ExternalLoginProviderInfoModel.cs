using Abp.AutoMapper;
using Yoyosoft.BookList.Authentication.External;

namespace Yoyosoft.BookList.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
