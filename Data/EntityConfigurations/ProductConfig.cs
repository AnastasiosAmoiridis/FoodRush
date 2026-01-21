using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Data.EntityConfigurations
{
    internal sealed class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", t =>
            {
                t.HasCheckConstraint(EntityConstraints.CK_PRODUCT_BASEPRICE_MIN, EntityConstraints.CheckContraints[EntityConstraints.CK_PRODUCT_BASEPRICE_MIN]);
            });

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasDefaultValueSql(EntityConstraints.DEFAULT_SQL_KEY_VALUE);

            builder.Property(p => p.Name)
                   .HasMaxLength(EntityConstraints.MAX_NAME_LENGTH);

            builder.Property(p => p.ImageUrl)
                   .HasMaxLength (EntityConstraints.MAX_URL_LENGTH);
        }
    }
}
