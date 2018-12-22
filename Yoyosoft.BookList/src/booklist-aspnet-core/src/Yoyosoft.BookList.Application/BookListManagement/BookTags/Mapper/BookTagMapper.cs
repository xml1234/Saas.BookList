
using AutoMapper;
using Yoyosoft.BookList.BookListManagement.BookTags;
using Yoyosoft.BookList.BookListManagement.BookTags.Dtos;
using Yoyosoft.BookList.BookListManagement.Dtos;

namespace Yoyosoft.BookList.BookListManagement.BookTags.Mapper
{

	/// <summary>
    /// 配置BookTag的AutoMapper
    /// </summary>
	internal static class BookTagMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <BookTag,BookTagListDto>();
            configuration.CreateMap <BookTagListDto,BookTag>();

            configuration.CreateMap <BookTagEditDto,BookTag>();
            configuration.CreateMap <BookTag,BookTagEditDto>();

            configuration.CreateMap<BookTag, BookTagSelectListDto>()
                .ForMember(a => a.IsSelected, options => options.Ignore());
        }
	}
}
