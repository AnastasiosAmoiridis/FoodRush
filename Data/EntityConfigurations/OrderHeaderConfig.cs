using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Data.EntityConfigurations
{
    internal sealed class OrderHeaderConfig : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            builder.ToTable("OrderHeaders", t =>
            {
                t.HasCheckConstraint(EntityConstraints.CK_ORDERHEADER_RATING_BOUNDARIES, EntityConstraints.CheckContraints[EntityConstraints.CK_ORDERHEADER_RATING_BOUNDARIES]);
            });

            builder.HasKey(oh => oh.Id);

            builder.Property(oh => oh.Id)
                   .HasDefaultValueSql(EntityConstraints.DEFAULT_SQL_KEY_VALUE);

            builder.Property(oh => oh.Notes)
                   .HasMaxLength(EntityConstraints.MAX_INSTRUCTION_LENGTH);

            builder.Property(oh => oh.Rating)
                   .HasPrecision(3, 2);

            builder.HasOne(oh => oh.Customer)
                   .WithMany(c => c.OrderHeaders)
                   .HasForeignKey(oh => oh.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(oh => oh.PaymentCode)
                   .WithMany(c => c.PaymentOrderHeaders)
                   .HasForeignKey(oh => oh.PaymentCodeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(oh => oh.OrderStatus)
                   .WithMany(c => c.OrderStatusOrderHeaders)
                   .HasForeignKey(oh => oh.OrderStatusCodeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
