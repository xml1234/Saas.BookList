

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Yoyosoft.BookList.BookListManagement.BookTags;

namespace Yoyosoft.BookList.BookListManagement.BookTags.Dtos
{
    public class CreateOrUpdateBookTagInput
    {
        [Required]
        public BookTagEditDto BookTag { get; set; }

    }
}