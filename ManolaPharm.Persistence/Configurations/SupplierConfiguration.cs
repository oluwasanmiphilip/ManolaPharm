using ManolaPharm.Domain.Entities.Supplier;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManolaPharm.Persistence.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(s => s.Email)
                .HasMaxLength(100);

            builder.Property(s => s.Phone)
                .HasMaxLength(20);

            builder.Property(s => s.Address)
                .HasMaxLength(200);

            builder.Property(s => s.City)
                .HasMaxLength(100);

            builder.Property(s => s.State)
                .HasMaxLength(100);

            builder.Property(s => s.Country)
                .HasMaxLength(100);

            builder.Property(s => s.Notes)
                .HasMaxLength(500);
        }
    }
}
