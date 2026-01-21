using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Data.EntityConfigurations
{
    internal sealed class GlobalProductCategoryConfig : IEntityTypeConfiguration<GlobalProductCategory>
    {
        public void Configure(EntityTypeBuilder<GlobalProductCategory> builder)
        {
            builder.ToTable("GlobalProductCategories");

            builder.HasKey(gpc => gpc.Id);

            builder.Property(gpc => gpc.Id)
                   .HasDefaultValueSql(EntityConstraints.DEFAULT_SQL_KEY_VALUE);

            builder.Property(gpc => gpc.Type)
                   .IsRequired();

            builder.HasAlternateKey(gpc => gpc.Type);                   
        }
    }
}
