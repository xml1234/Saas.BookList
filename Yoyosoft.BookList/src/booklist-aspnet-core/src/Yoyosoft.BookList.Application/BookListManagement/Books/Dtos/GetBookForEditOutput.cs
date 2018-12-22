

using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Yoyosoft.BookList.BookListManagement;

namespace Yoyosoft.BookList.BookListManagement.Dtos
{
    public class GetBookForEditOutput
    {

        public BookEditDto Book { get; set; }

        public List<BookTagSelectListDto> BookTags { get; set; }

    }
}