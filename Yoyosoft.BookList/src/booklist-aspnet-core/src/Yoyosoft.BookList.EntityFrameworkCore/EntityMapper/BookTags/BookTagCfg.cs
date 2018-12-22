

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yoyosoft.BookList.BookListManagement.BookTags;

namespace Yoyosoft.BookList.EntityMapper.BookTags
{
    public class BookTagCfg : IEntityTypeConfiguration<BookTag>
    {
        public void Configure(EntityTypeBuilder<BookTag> builder)
        {

            builder.ToTable("BookTags", YoYoAbpefCoreConsts.SchemaNames.CMS);

            
			builder.Property(a => a.TagName).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);


        }
    }
}


