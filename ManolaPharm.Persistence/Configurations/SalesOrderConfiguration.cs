using ManolaPharm.Domain.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManolaPharm.Persistence.Configurations
{
    public class SalesOrderConfiguration : IEntityTypeConfiguration<SalesOrder>
    {
        public void Configure(EntityTypeBuilder<SalesOrder> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.OrderNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.Status)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(s => s.TotalAmount)
                .HasColumnType("decimal(18,2)");

            builder.Property(s => s.Remarks)
                .HasMaxLength(250);

            builder.Property(s => s.IsActive)
                .HasDefaultValue(true);
        }
    }
}
