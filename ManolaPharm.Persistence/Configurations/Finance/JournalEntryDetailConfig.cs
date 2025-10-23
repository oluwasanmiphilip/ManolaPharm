using ManolaPharm.Domain.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManolaPharm.Persistence.Configurations
{
    public class JournalEntryDetailConfig : IEntityTypeConfiguration<JournalEntryDetail>
    {
        public void Configure(EntityTypeBuilder<JournalEntryDetail> builder)
        {
            builder.Property(d => d.Debit)
                   .HasColumnType("decimal(18,2)");

            builder.Property(d => d.Credit)
                   .HasColumnType("decimal(18,2)");

            builder.Property(d => d.AccountCode)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(d => d.AccountName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(d => d.Description)
                   .HasMaxLength(250);

            builder.Property(d => d.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(d => d.IsActive)
                   .HasDefaultValue(true);

            builder.HasOne(d => d.JournalEntry)
                   .WithMany()
                   .HasForeignKey(d => d.JournalEntryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
