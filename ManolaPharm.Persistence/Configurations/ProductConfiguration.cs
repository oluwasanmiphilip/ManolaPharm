using ManolaPharm.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManolaPharm.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Description).HasMaxLength(300);
            builder.Property(p => p.Category).HasMaxLength(100);
            builder.Property(p => p.Manufacturer).HasMaxLength(150);
            builder.Property(p => p.BatchNumber).HasMaxLength(100);
            builder.Property(p => p.UnitPrice).HasColumnType("decimal(18,2)");
        }
    }
}
