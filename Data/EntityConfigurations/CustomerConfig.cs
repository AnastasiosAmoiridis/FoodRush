using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;
using Common;

namespace Data.EntityConfigurations
{
    internal sealed class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasDefaultValueSql(EntityConstraints.DEFAULT_SQL_KEY_VALUE);

            builder.Property(c => c.Phone)
                   .IsRequired()
                   .HasMaxLength(EntityConstraints.MAX_PHONE_LENGTH);

            builder.HasIndex(c => c.Phone)
                   .IsUnique();

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(EntityConstraints.MAX_EMAIL_LENGTH);

            builder.HasAlternateKey(c => c.Email);
        }
    }
}
