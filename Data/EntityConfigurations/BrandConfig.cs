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

            // Name property
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasIndex(b => b.Id)
                .IsUnique();

            // LogoUrl property
            builder.Property(b => b.LogoUrl)
                .IsRequired();

            builder.HasIndex(b => b.LogoUrl)
                .IsUnique();
        }
    }
}
