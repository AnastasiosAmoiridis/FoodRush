using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Junctions;

namespace Data.EntityConfigurations.Junctions
{
    internal sealed class GlobalFilterProductOverrideConfig : IEntityTypeConfiguration<GlobalFilterProductOverride>
    {
        public void Configure(EntityTypeBuilder<GlobalFilterProductOverride> builder)
        {
            builder.ToTable("GlobalFilterProductOverrides");

            builder.HasKey(gfpo => new { gfpo.ProductId, gfpo.GlobalFilterId });

            builder.HasOne(gfpo => gfpo.GlobalFilter)
                   .WithMany(gf => gf.GlobalFilterProductOverrides)
                   .HasForeignKey(gfpo => gfpo.GlobalFilterId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(gfpo => gfpo.Product)
                   .WithMany(p => p.GlobalFilterProductOverrides)
                   .HasForeignKey(gfpo => gfpo.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
