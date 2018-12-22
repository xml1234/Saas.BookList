
using AutoMapper;
using Yoyosoft.BookList.BookListManagement.CloludBookLists;
using Yoyosoft.BookList.BookListManagement.CloludBookLists.Dtos;

namespace Yoyosoft.BookList.BookListManagement.CloludBookLists.Mapper
{

	/// <summary>
    /// 配置CloludBookList的AutoMapper
    /// </summary>
	internal static class CloludBookListMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <CloludBookList,CloludBookListListDto>();
            configuration.CreateMap <CloludBookListListDto,CloludBookList>();

            configuration.CreateMap <CloludBookListEditDto,CloludBookList>();
            configuration.CreateMap <CloludBookList,CloludBookListEditDto>();

        }
	}
}
