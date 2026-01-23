using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities;

namespace Data.EntityConfigurations
{
    internal sealed class CodeConfig : IEntityTypeConfiguration<Code>
    {
        public void Configure(EntityTypeBuilder<Code> builder)
        {
            builder.ToTable("Codes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasDefaultValueSql(EntityConstraints.DEFAULT_SQL_KEY_VALUE);

            builder.Property(c => c.Description)
                   .HasMaxLength(EntityConstraints.MAX_CODE_DEFINITION_DESCRIPTION_LENGTH);

            builder.HasAlternateKey(c => c.Description);

            builder.HasOne(c => c.CodeDefinition)
                   .WithMany(cd => cd.Codes)
                   .HasForeignKey(c => c.CodeDefinitionId)
                   .OnDelete(DeleteBehavior.Restrict);  
        }
    }
}
