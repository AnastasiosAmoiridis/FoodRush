using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;
using Common;

namespace Data.EntityConfigurations
{
    internal sealed class BrandProductCategoryConfig : IEntityTypeConfiguration<BrandProductCategory>
    {
        public void Configure(EntityTypeBuilder<BrandProductCategory> builder)
        {
            builder.ToTable("BrandProductCategories");

            builder.HasKey(bpc => bpc.Id);

            builder.Property(bpc => bpc.Id)
                   .HasDefaultValueSql(EntityConstraints.DEFAULT_SQL_KEY_VALUE);

            builder.Property(bpc => bpc.Name)
                   .IsRequired()
                   .HasMaxLength(EntityConstraints.MAX_NAME_LENGTH);

            builder.HasOne(bpc => bpc.Brand)
                   .WithMany(b => b.BrandProductCategories)
                   .HasForeignKey(bpc => bpc.BrandId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(bpc => bpc.GlobalProductCategory)
                   .WithMany(gpc => gpc.BrandProductCategories)
                   .HasForeignKey(bpc => bpc.GlobalProductCategoryId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
