using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Yoyosoft.BookList.Authorization;
using Yoyosoft.BookList.BookListManagement.Authorization;
using Yoyosoft.BookList.BookListManagement.BookTags.Authorization;
using Yoyosoft.BookList.BookListManagement.BookTags.Mapper;
using Yoyosoft.BookList.BookListManagement.CloludBookLists.Authorization;
using Yoyosoft.BookList.BookListManagement.CloludBookLists.Mapper;
using Yoyosoft.BookList.BookListManagement.Mapper;

namespace Yoyosoft.BookList
{
    [DependsOn(
        typeof(BookListCoreModule),
        typeof(AbpAutoMapperModule))]
    public class BookListApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BookListAuthorizationProvider>();

            //给book定义授权信息内容
            Configuration.Authorization.Providers.Add<BookAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<BookTagAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<CloludBookListAuthorizationProvider>();

            // 自定义类型映射
            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
            {
                // XXXMapper.CreateMappers(configuration);
                BookMapper.CreateMappings(configuration);
                BookTagMapper.CreateMappings(configuration);
                CloludBookListMapper.CreateMappings(configuration);

            });
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BookListApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
