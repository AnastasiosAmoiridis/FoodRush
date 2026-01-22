using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Data.EntityConfigurations
{
    internal sealed class CustomerAddressConfig : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.ToTable("CustomerAddresses");

            builder.HasKey(ca => ca.Id);

            builder.Property(ca => ca.Id)
                   .HasDefaultValueSql(EntityConstraints.DEFAULT_SQL_KEY_VALUE);

            builder.Property(ca => ca.Street)
                   .HasMaxLength(EntityConstraints.MAX_STREET_LENGTH);

            builder.Property(ca => ca.City)
                   .HasMaxLength(EntityConstraints.MAX_CITY_LENGTH);

            builder.Property(ca => ca.DoorbellName)
                   .HasMaxLength(EntityConstraints.MAX_NAME_LENGTH);

            builder.Property(ca => ca.PostalCode)
                   .HasMaxLength(EntityConstraints.MAX_POSTALCODE_LENGTH);

            builder.Property(ca => ca.Instructions)
                   .HasMaxLength(EntityConstraints.MAX_INSTRUCTION_LENGTH);

            builder.Property(ca => ca.Latitude)
                   .HasPrecision(9, 6);

            builder.Property(ca => ca.Longitude)
                   .HasPrecision(9, 6);

            builder.HasOne(ca => ca.Customer)
                   .WithMany(c => c.Addresses)
                   .HasForeignKey(ca => ca.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
