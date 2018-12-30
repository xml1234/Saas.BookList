using System.Collections.Generic;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Yoyosoft.BookList.BookListManagement.Relationships;

namespace Yoyosoft.BookList.BookListManagement.CloludBookLists
{
    public class CloludBookList:CreationAuditedEntity<long>, IMustHaveTenant
    {
        public string Name { get; set; }

        public string Intro { get; set; }

        public virtual ICollection<BookListAndBook> BookListAndBooks { get; set; }


        public int TenantId { get; set; }
    }
}
