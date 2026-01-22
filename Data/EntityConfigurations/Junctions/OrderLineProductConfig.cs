using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Junctions;

namespace Data.EntityConfigurations.Junctions
{
    internal sealed class OrderLineProductConfig : IEntityTypeConfiguration<OrderLineProduct>
    {
        public void Configure(EntityTypeBuilder<OrderLineProduct> builder)
        {
            builder.ToTable("OrderLineProducts", t =>
            {
                t.HasCheckConstraint(EntityConstraints.CK_ORDERLINE_PRODUCT_PRODUCTCOUNT_MIN, EntityConstraints.CheckContraints[EntityConstraints.CK_ORDERLINE_PRODUCT_PRODUCTCOUNT_MIN]);
            });

            builder.HasKey(olp => new { olp.OrderLineId, olp.ProductId });

            builder.Property(olp => olp.LinePrice)
                   .HasPrecision(18, 2);

            builder.HasOne(olp => olp.Product)
                   .WithMany(p => p.OrderLineProducts)
                   .HasForeignKey(olp => olp.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(olp => olp.OrderLine)
                   .WithMany(ol => ol.OrderLineProducts)
                   .HasForeignKey(olp => olp.OrderLineId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
