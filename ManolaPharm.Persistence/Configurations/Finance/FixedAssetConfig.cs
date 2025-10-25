using ManolaPharm.Domain.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManolaPharm.Persistence.Configurations.Finance
{
    public class FixedAssetConfig : IEntityTypeConfiguration<FixedAsset>
    {
        public void Configure(EntityTypeBuilder<FixedAsset> builder)
        {
            builder.ToTable("FixedAssets");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.AssetName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(f => f.AssetCode)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(f => f.Category)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(f => f.Cost)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(f => f.AccumulatedDepreciation)
                .HasPrecision(18, 2);

            builder.Property(f => f.ResidualValue)
                .HasPrecision(18, 2);

            builder.Property(f => f.Department)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(f => f.DepreciationMethod)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
