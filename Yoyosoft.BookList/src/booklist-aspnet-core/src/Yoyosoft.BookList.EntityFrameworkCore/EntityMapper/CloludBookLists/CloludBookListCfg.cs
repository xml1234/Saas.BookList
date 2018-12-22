

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yoyosoft.BookList.BookListManagement.CloludBookLists;

namespace Yoyosoft.BookList.EntityMapper.CloludBookLists
{
    public class CloludBookListCfg : IEntityTypeConfiguration<CloludBookList>
    {
        public void Configure(EntityTypeBuilder<CloludBookList> builder)
        {

            builder.ToTable("CloludBookLists", YoYoAbpefCoreConsts.SchemaNames.CMS);

            
			builder.Property(a => a.Name).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.Intro).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);
			builder.Property(a => a.BookListAndBooks).HasMaxLength(YoYoAbpefCoreConsts.EntityLengthNames.Length64);


        }
    }
}


