using Abp.Domain.Entities.Auditing;
using Yoyosoft.BookList.BookListManagement.CloludBookLists;

namespace Yoyosoft.BookList.BookListManagement.Relationships
{
    public class BookListAndBook:CreationAuditedEntity<long>
    {
        public long CloudBookListId { get; set; }

        public CloludBookList CloludBookList { get; set; }

        public long BookId { get; set; }

        public Book Book { get; set; }

    }
}