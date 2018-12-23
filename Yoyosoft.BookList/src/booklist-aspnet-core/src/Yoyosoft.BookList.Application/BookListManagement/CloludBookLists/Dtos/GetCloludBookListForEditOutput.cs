

using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Yoyosoft.BookList.BookListManagement.CloludBookLists;
using Yoyosoft.BookList.BookListManagement.Dtos;

namespace Yoyosoft.BookList.BookListManagement.CloludBookLists.Dtos
{
    public class GetCloludBookListForEditOutput
    {

        public CloludBookListEditDto CloludBookList { get; set; }

        public List<BookSelectListDto> Books { get; set; }

    }
}