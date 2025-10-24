using ManolaPharm.Domain.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManolaPharm.Persistence.Configurations.Finance
{
    public class ChartOfAccountConfig : IEntityTypeConfiguration<ChartOfAccount>
    {
        public void Configure(EntityTypeBuilder<ChartOfAccount> builder)
        {
            // ✅ Table name
            builder.ToTable("ChartOfAccounts");

            // ✅ Primary Key
            builder.HasKey(c => c.Id);

            // ✅ Account Code
            builder.Property(c => c.AccountCode)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.HasIndex(c => c.AccountCode)
                   .IsUnique();

            // ✅ Account Name
            builder.Property(c => c.AccountName)
                   .IsRequired()
                   .HasMaxLength(100);

            // ✅ Account Type (Asset, Liability, Equity, Income, Expense)
            builder.Property(c => c.AccountType)
                   .IsRequired()
                   .HasMaxLength(30);

            // ✅ Description
            builder.Property(c => c.Description)
                   .HasMaxLength(250);

            // ✅ Balance
            builder.Property(c => c.Balance)
                   .HasColumnType("decimal(18,2)")
                   .HasDefaultValue(0m);

            // ✅ Status and audit fields
            builder.Property(c => c.IsActive)
                   .HasDefaultValue(true);

            builder.Property(c => c.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(c => c.UpdatedAt)
                   .IsRequired(false);
        }
    }
}
