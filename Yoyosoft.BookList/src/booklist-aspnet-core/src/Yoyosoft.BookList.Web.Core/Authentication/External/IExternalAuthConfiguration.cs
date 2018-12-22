using System.Collections.Generic;

namespace Yoyosoft.BookList.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
