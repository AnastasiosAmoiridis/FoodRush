using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Entities.Auth;

namespace Data.EntityConfigurations.Auth
{
    internal sealed class RefreshTokenConfig : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("RefreshTokens");

            builder.HasKey(rt => rt.Id);

            builder.Property(rt => rt.Id)
                   .HasDefaultValueSql(EntityConstraints.DEFAULT_SQL_KEY_VALUE);

            builder.HasOne(rt => rt.IdentityUser)
                   .WithMany(friu => friu.RefreshTokens)
                   .HasForeignKey(rt => rt.IdentityUserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(rt => rt.ReplacedByToken)
                   .WithOne()
                   .HasForeignKey<RefreshToken>(rt => rt.ReplacedByTokenId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
