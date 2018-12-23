
using AutoMapper;
using Yoyosoft.BookList.BookListManagement;
using Yoyosoft.BookList.BookListManagement.Dtos;

namespace Yoyosoft.BookList.BookListManagement.Mapper
{

	/// <summary>
    /// 配置Book的AutoMapper
    /// </summary>
	internal static class BookMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Book,BookListDto>();
            configuration.CreateMap <BookListDto,Book>();

            configuration.CreateMap <BookEditDto,Book>();
            configuration.CreateMap <Book,BookEditDto>();

            configuration.CreateMap<Book, BookSelectListDto>()
                .ForMember(a => a.IsSelected, options => options.Ignore());

        }
	}
}
