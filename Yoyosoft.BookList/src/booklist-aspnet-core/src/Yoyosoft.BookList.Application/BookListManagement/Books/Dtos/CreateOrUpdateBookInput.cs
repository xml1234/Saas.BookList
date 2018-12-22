

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Yoyosoft.BookList.BookListManagement;

namespace Yoyosoft.BookList.BookListManagement.Dtos
{
    public class CreateOrUpdateBookInput
    {
        [Required]
        public BookEditDto Book { get; set; }

        public List<long> TagIds { set; get; }

    }
}