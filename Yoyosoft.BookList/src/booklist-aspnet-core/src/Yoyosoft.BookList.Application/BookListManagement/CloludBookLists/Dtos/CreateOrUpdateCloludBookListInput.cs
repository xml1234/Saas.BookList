

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Yoyosoft.BookList.BookListManagement.CloludBookLists;

namespace Yoyosoft.BookList.BookListManagement.CloludBookLists.Dtos
{
    public class CreateOrUpdateCloludBookListInput
    {
        [Required]
        public CloludBookListEditDto CloludBookList { get; set; }

    }
}