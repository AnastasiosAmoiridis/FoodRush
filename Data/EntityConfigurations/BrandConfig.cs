using Common;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Data.EntityConfigurations
{
    internal sealed class BrandConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                   .HasDefaultValueSql(EntityConstraints.DEFAULT_SQL_KEY_VALUE);

            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(EntityConstraints.MAX_NAME_LENGTH);

            builder.Property(b => b.LogoUrl)
                   .IsRequired()
                   .HasMaxLength(EntityConstraints.MAX_URL_LENGTH);
        }
    }
}
