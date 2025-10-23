using ManolaPharm.Domain.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManolaPharm.Persistence.Configurations.Finance
{
    public class AccountsPayableConfig : IEntityTypeConfiguration<AccountsPayable>
    {
        public void Configure(EntityTypeBuilder<AccountsPayable> builder)
        {
            builder.ToTable("AccountsPayables");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AmountOwed)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.AmountPaid)
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);

            builder.Property(x => x.Status)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Remarks)
                .HasMaxLength(250);

            builder.Property(x => x.CreatedAt)
                .IsRequired();
        }
    }
}
