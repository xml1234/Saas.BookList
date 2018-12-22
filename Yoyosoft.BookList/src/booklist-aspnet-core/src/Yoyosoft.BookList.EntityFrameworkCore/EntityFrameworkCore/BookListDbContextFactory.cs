using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Yoyosoft.BookList.Configuration;
using Yoyosoft.BookList.Web;

namespace Yoyosoft.BookList.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class BookListDbContextFactory : IDesignTimeDbContextFactory<BookListDbContext>
    {
        public BookListDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BookListDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            BookListDbContextConfigurer.Configure(builder, configuration.GetConnectionString(BookListConsts.ConnectionStringName));

            return new BookListDbContext(builder.Options);
        }
    }
}
