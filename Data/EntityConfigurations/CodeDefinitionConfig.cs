using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Data.EntityConfigurations
{
    internal sealed class CodeDefinitionConfig : IEntityTypeConfiguration<CodeDefinition>
    {
        public void Configure(EntityTypeBuilder<CodeDefinition> builder)
        {
            builder.ToTable("CodeDefinitions");

            builder.HasKey(cd => cd.Id);

            builder.HasAlternateKey(cd => cd.Description);

            builder.Property(cd => cd.Id)
                   .HasDefaultValueSql(EntityConstraints.DEFAULT_SQL_KEY_VALUE);

            builder.Property(cd => cd.Description)
                   .HasMaxLength(EntityConstraints.MAX_CODE_DEFINITION_DESCRIPTION_LENGTH);
        }
    }
}
