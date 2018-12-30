using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Yoyosoft.BookList.BookListManagement.Relationships;

namespace Yoyosoft.BookList.BookListManagement
{
    public class Book:CreationAuditedEntity<long>,IMustHaveTenant
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public string Intro { get; set; }

        public string PriceUrl { get; set; }

        public string ImgUrl { get; set; }

        public virtual ICollection<BookAndBookTag> BookAndBookTags { get; set; }

        public virtual ICollection<BookListAndBook> BookListAndBooks { get; set; }


        public int TenantId { get; set; }
    }
}
