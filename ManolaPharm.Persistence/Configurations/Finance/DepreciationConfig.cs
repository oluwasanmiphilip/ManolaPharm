using ManolaPharm.Domain.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManolaPharm.Persistence.Configurations.Finance
{
    public class DepreciationConfig : IEntityTypeConfiguration<Depreciation>
    {
        public void Configure(EntityTypeBuilder<Depreciation> builder)
        {
            builder.ToTable("Depreciations");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.DepreciationAmount)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(d => d.AccumulatedDepreciation)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(d => d.BookValue)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(d => d.Remarks)
                   .HasMaxLength(250);

            builder.HasOne(d => d.FixedAsset)
                   .WithMany()
                   .HasForeignKey(d => d.FixedAssetId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
