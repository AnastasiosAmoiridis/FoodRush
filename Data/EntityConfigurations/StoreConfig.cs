using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Data.EntityConfigurations
{
    internal sealed class StoreConfig : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Stores", t =>
            {
                t.HasCheckConstraint(EntityConstraints.CK_STORE_PHONE_MIN, EntityConstraints.CheckContraints[EntityConstraints.CK_STORE_PHONE_MIN]);
            });

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                   .HasDefaultValueSql(EntityConstraints.DEFAULT_SQL_KEY_VALUE);

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(EntityConstraints.MAX_NAME_LENGTH);

            builder.Property(s => s.Phone)
                   .HasMaxLength(EntityConstraints.MAX_PHONE_LENGTH);

            builder.Property(s => s.ImageUrl)
                   .HasMaxLength(EntityConstraints.MAX_URL_LENGTH);

            builder.HasIndex(s => s.Phone)
                   .IsUnique();

            builder.HasOne(s => s.Brand)
                   .WithMany(b => b.Stores)
                   .HasForeignKey(s => s.BrandId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
