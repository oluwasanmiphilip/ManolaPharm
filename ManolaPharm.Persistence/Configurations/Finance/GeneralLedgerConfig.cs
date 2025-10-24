using ManolaPharm.Domain.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManolaPharm.Persistence.Configurations.Finance
{
    public class GeneralLedgerConfig : IEntityTypeConfiguration<GeneralLedger>
    {
        public void Configure(EntityTypeBuilder<GeneralLedger> builder)
        {
            builder.Property(g => g.AccountName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(g => g.AccountCode)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(g => g.Debit)
                   .HasColumnType("decimal(18,2)");

            builder.Property(g => g.Credit)
                   .HasColumnType("decimal(18,2)");

            builder.Property(g => g.Balance)
                   .HasColumnType("decimal(18,2)");

            builder.Property(g => g.Description)
                   .HasMaxLength(500);

            builder.Property(g => g.Status)
                   .HasMaxLength(20)
                   .HasDefaultValue("Active");

            builder.Property(g => g.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(g => g.IsActive)
                   .HasDefaultValue(true);
        }
    }
}
