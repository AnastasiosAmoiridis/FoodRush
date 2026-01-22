using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Junctions;

namespace Data.EntityConfigurations.Junctions
{
    internal sealed class GlobalFilterGlobalCategoryConfig : IEntityTypeConfiguration<GlobalFilterGlobalCategory>
    {
        public void Configure(EntityTypeBuilder<GlobalFilterGlobalCategory> builder)
        {
            builder.ToTable("GlobalFilterGlobalCategories");

            builder.HasKey(gfgc => new { gfgc.GlobalProductCategoryId, gfgc.GlobalFilterId });

            builder.HasOne(gfgc => gfgc.GlobalProductCategory)
                   .WithMany(gpc => gpc.GlobalFilterGlobalCategories)
                   .HasForeignKey(gfgc => gfgc.GlobalProductCategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(gfgc => gfgc.GlobalFilter)
                   .WithMany(gf => gf.GlobalFilterGlobalCategories)
                   .HasForeignKey(gfgc => gfgc.GlobalFilterId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
