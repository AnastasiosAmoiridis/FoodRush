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

            SeedData(builder);
        }

        private static void SeedData(EntityTypeBuilder<CodeDefinition> builder)
        {
            builder.HasData(
                new CodeDefinition
                {
                    Id = Guid.Parse("8F2A6C3E-4B91-4D6C-9C3F-1A7E9F2B0A11"),
                    Description = "Payment",
                    IsActive = true,
                    IsDeleted = false
                },
                new CodeDefinition
                {
                    Id = Guid.Parse("3C9E1F72-0A5D-4E8B-B7A4-9D6F2C1E4B22"),
                    Description = "OrderStatus",
                    IsActive = true,
                    IsDeleted = false
                }
            );
        }
    }
}
