using ManolaPharm.Domain.Entities.Purchasing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManolaPharm.Persistence.Configurations
{
    public class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.OrderNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Status)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.TotalAmount)
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Remarks)
                .HasMaxLength(250);

            builder.Property(p => p.IsActive)
                .HasDefaultValue(true);

            // ✅ No shadow FKs — we’ll link manually later
        }
    }
}
