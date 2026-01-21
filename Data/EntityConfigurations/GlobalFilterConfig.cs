using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Data.EntityConfigurations
{
    internal sealed class GlobalFilterConfig : IEntityTypeConfiguration<GlobalFilter>
    {
        public void Configure(EntityTypeBuilder<GlobalFilter> builder)
        {
            builder.ToTable("GlobalFilters");

            builder.HasKey(gf => gf.Id);

            builder.Property(gf => gf.Id)
                   .HasDefaultValueSql(EntityConstraints.DEFAULT_SQL_KEY_VALUE);
        }
    }
}
