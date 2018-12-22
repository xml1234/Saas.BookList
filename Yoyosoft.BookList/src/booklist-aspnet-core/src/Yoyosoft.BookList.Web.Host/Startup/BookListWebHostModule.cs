using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Yoyosoft.BookList.Configuration;

namespace Yoyosoft.BookList.Web.Host.Startup
{
    [DependsOn(
       typeof(BookListWebCoreModule))]
    public class BookListWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BookListWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BookListWebHostModule).GetAssembly());
        }
    }
}
