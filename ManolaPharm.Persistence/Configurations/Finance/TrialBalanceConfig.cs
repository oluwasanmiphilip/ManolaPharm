using ManolaPharm.Domain.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManolaPharm.Persistence.Configurations
{
    public class TrialBalanceConfig : IEntityTypeConfiguration<TrialBalance>
    {
        public void Configure(EntityTypeBuilder<TrialBalance> builder)
        {
            builder.Property(t => t.AccountName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(t => t.AccountCode)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(t => t.Debit)
                   .HasColumnType("decimal(18,2)");

            builder.Property(t => t.Credit)
                   .HasColumnType("decimal(18,2)");

            builder.Property(t => t.IsActive)
                   .HasDefaultValue(true);

            builder.Property(t => t.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
