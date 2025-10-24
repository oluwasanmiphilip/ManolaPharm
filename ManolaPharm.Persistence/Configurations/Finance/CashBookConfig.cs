using ManolaPharm.Domain.Entities.Finance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManolaPharm.Persistence.Configurations.Finance
{
    public class CashBookConfig : IEntityTypeConfiguration<CashBook>
    {
        public void Configure(EntityTypeBuilder<CashBook> builder)
        {
            builder.Property(c => c.Amount)
                   .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Status)
                   .HasColumnType("nvarchar(20)")
                   .HasMaxLength(20)
                   .HasDefaultValue("Pending");

            builder.Property(c => c.Remarks)
                   .HasMaxLength(250);

            builder.Property(c => c.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(c => c.IsActive)
                   .HasDefaultValue(true);
        }
    }
}
