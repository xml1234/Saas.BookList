using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Yoyosoft.BookList.Authorization.Roles;
using Yoyosoft.BookList.Authorization.Users;
using Yoyosoft.BookList.BookListManagement;
using Yoyosoft.BookList.BookListManagement.BookTags;
using Yoyosoft.BookList.BookListManagement.CloludBookLists;
using Yoyosoft.BookList.BookListManagement.Relationships;
using Yoyosoft.BookList.MultiTenancy;

namespace Yoyosoft.BookList.EntityFrameworkCore
{
    public class BookListDbContext : AbpZeroDbContext<Tenant, Role, User, BookListDbContext>
    {
        /* Define a DbSet for each entity of the application */


        public DbSet<Book> Books { get; set; }

        public DbSet<CloludBookList> CloludBookLists { get; set; }

        public DbSet<BookTag> BookTags { get; set; }

        public DbSet<BookAndBookTag> BookAndBookTags { get; set; }

        public DbSet<BookListAndBook> BookListAndBooks { get; set; }


        public BookListDbContext(DbContextOptions<BookListDbContext> options)
            : base(options)
        {
        }
    }
}
