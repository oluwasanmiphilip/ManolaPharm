using ManolaPharm.Domain.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManolaPharm.Persistence.Configurations
{
    public class AccountsReceivableConfiguration : IEntityTypeConfiguration<AccountsReceivable>
    {
        public void Configure(EntityTypeBuilder<AccountsReceivable> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.AmountDue)
                .HasColumnType("decimal(18,2)");

            builder.Property(a => a.AmountPaid)
                .HasColumnType("decimal(18,2)");

            builder.Property(a => a.Status)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(a => a.Remarks)
                .HasMaxLength(250);

            builder.Property(a => a.IsActive)
                .HasDefaultValue(true);
        }
    }
}
