using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Yoyosoft.BookList.EntityFrameworkCore
{
    public static class BookListDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BookListDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString, p => p.UseRowNumberForPaging());
        }

        public static void Configure(DbContextOptionsBuilder<BookListDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
