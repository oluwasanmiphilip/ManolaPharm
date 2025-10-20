using ManolaPharm.Domain.Entities.Inventory;
using ManolaPharm.Domain.Entities.Warehouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManolaPharm.Persistence.Configurations
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(w => w.Location)
                .HasMaxLength(150);

            builder.Property(w => w.Manager)
                .HasMaxLength(100);

            builder.Property(w => w.Phone)
                .HasMaxLength(20);

            builder.Property(w => w.Email)
                .HasMaxLength(100);

            builder.Property(w => w.Address)
                .HasMaxLength(200);

            builder.Property(w => w.City)
                .HasMaxLength(100);

            builder.Property(w => w.State)
                .HasMaxLength(100);

            builder.Property(w => w.Country)
                .HasMaxLength(100);

            builder.Property(w => w.Capacity)
                .HasColumnType("decimal(18,2)");

            builder.Property(w => w.IsActive)
                .HasDefaultValue(true);
        }
    }
}
