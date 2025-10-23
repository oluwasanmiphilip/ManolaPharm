using ManolaPharm.Domain.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManolaPharm.Persistence.Configurations.Finance
{
    public class JournalEntryConfig : IEntityTypeConfiguration<JournalEntry>
    {
        public void Configure(EntityTypeBuilder<JournalEntry> builder)
        {
            builder.Property(j => j.EntryNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(j => j.EntryDate)
                   .IsRequired();

            builder.Property(j => j.AccountName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(j => j.AccountCode)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(j => j.Debit)
                   .HasColumnType("decimal(18,2)")
                   .HasDefaultValue(0m);

            builder.Property(j => j.Credit)
                   .HasColumnType("decimal(18,2)")
                   .HasDefaultValue(0m);

            builder.Property(j => j.Description)
                   .HasMaxLength(500);

            builder.Property(j => j.Status)
                   .IsRequired()
                   .HasMaxLength(20)
                   .HasDefaultValue("Pending");

            builder.Property(j => j.IsActive)
                   .HasDefaultValue(true);

            builder.Property(j => j.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(j => j.UpdatedAt)
                   .IsRequired(false);
        }
    }
}
