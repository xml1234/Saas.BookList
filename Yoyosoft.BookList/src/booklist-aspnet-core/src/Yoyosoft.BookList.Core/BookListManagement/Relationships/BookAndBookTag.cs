using Abp.Domain.Entities;
using Yoyosoft.BookList.BookListManagement.BookTags;

namespace Yoyosoft.BookList.BookListManagement.Relationships
{
    public class BookAndBookTag:Entity<long>, IMustHaveTenant
    {
        public long BookId { get; set; }

        public virtual Book Book { get; set; }

        public long BookTagId { get; set; }

        public virtual BookTag BookTag { get; set; }
        public int TenantId { get; set; }
    }
}