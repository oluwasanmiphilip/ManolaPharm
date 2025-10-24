using ManolaPharm.Domain.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManolaPharm.Persistence.Configurations.Finance
{
    public class BankReconciliationConfig : IEntityTypeConfiguration<BankReconciliation>
    {
        public void Configure(EntityTypeBuilder<BankReconciliation> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.AccountNumber)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(b => b.BankName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(b => b.StatementDate)
                   .IsRequired();

            builder.Property(b => b.BankStatementBalance)
                   .HasColumnType("decimal(18,2)");

            builder.Property(b => b.BookBalance)
                   .HasColumnType("decimal(18,2)");

            builder.Property(b => b.OutstandingDeposits)
                   .HasColumnType("decimal(18,2)")
                   .HasDefaultValue(0);

            builder.Property(b => b.OutstandingPayments)
                   .HasColumnType("decimal(18,2)")
                   .HasDefaultValue(0);

            builder.Property(b => b.Remarks)
                   .HasMaxLength(250);

            builder.Property(b => b.IsReconciled)
                   .HasDefaultValue(false);

            builder.Property(b => b.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(b => b.IsActive)
                   .HasDefaultValue(true);
        }
    }
}
