using ManolaPharm.Domain.Entities.Finance;
using ManolaPharm.Domain.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManolaPharm.Persistence.Configurations
{
    public class AccountsReceivableConfig : IEntityTypeConfiguration<AccountsReceivable>
    {
        public void Configure(EntityTypeBuilder<AccountsReceivable> builder)
        {
            builder.Property(a => a.AmountOwed)
                   .HasColumnType("decimal(18,2)");

            builder.Property(a => a.AmountPaid)
                   .HasColumnType("decimal(18,2)")
                   .HasDefaultValue(0m);

            builder.Property(a => a.Status)
                   .HasMaxLength(20)
                   .HasDefaultValue("Pending");

            builder.Property(a => a.Remarks)
                   .HasMaxLength(250);

            builder.Property(a => a.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(a => a.IsActive)
                   .HasDefaultValue(true);

            builder.HasOne(a => a.SalesOrder)
                   .WithMany()
                   .HasForeignKey(a => a.SalesOrderId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
