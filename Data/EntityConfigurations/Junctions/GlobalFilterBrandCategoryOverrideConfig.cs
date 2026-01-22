using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Junctions;

namespace Data.EntityConfigurations.Junctions
{
    internal sealed class GlobalFilterBrandCategoryOverrideConfig : IEntityTypeConfiguration<GlobalFilterBrandCategoryOverride>
    {
        public void Configure(EntityTypeBuilder<GlobalFilterBrandCategoryOverride> builder)
        {
            builder.ToTable("GlobalFilterBrandCategoryOverrides");

            builder.HasKey(gfbco => new { gfbco.BrandProductCategoryId, gfbco.GlobalFilterId });

            builder.HasOne(gfbco => gfbco.BrandProductCategory)
                   .WithMany(bpc => bpc.GlobalFilterBrandCategoryOverrides)
                   .HasForeignKey(gfbco => gfbco.BrandProductCategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(gfbco => gfbco.GlobalFilter)
                   .WithMany(gf => gf.GlobalFilterBrandCategoryOverrides)
                   .HasForeignKey(gfbco => gfbco.GlobalFilterId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
