using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Data.EntityConfigurations
{
    internal sealed class StoreAddressConfig : IEntityTypeConfiguration<StoreAddress>
    {
        public void Configure(EntityTypeBuilder<StoreAddress> builder)
        {
            builder.ToTable("StoreAddresses");

            builder.HasKey(sa => sa.Id);

            builder.Property(sa => sa.Id)
                   .HasDefaultValueSql(EntityConstraints.DEFAULT_SQL_KEY_VALUE);

            builder.Property(sa => sa.PostalCode)
                   .HasMaxLength(EntityConstraints.MAX_POSTALCODE_LENGTH);

            builder.Property(sa => sa.Street)
                   .HasMaxLength(EntityConstraints.MAX_STREET_LENGTH);

            builder.Property(sa => sa.City)
                   .HasMaxLength(EntityConstraints.MAX_CITY_LENGTH);

            builder.Property(sa => sa.Latitude)
                   .HasPrecision(9, 6);

            builder.Property(sa => sa.Longitude)
                   .HasPrecision(9, 6);

            builder.HasOne(sa => sa.Store)
                   .WithOne(s => s.StoreAddress)
                   .HasForeignKey<StoreAddress>(sa => sa.StoreId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
