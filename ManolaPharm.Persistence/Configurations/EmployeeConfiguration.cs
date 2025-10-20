using ManolaPharm.Domain.Entities.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManolaPharm.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.LastName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Address)
                   .HasMaxLength(250);

            builder.Property(e => e.City)
                   .HasMaxLength(100);

            builder.Property(e => e.State)
                   .HasMaxLength(100);

            builder.Property(e => e.Country)
                   .HasMaxLength(100);

            builder.Property(e => e.Email)
                   .HasMaxLength(100);

            builder.Property(e => e.Phone)
                   .HasMaxLength(50);

            builder.Property(e => e.Status)
                   .HasMaxLength(50)
                   .HasDefaultValue("Active");

            builder.Property(e => e.IsActive)
                   .HasDefaultValue(true);

            // Relationships
            builder.HasOne(e => e.Department)
                   .WithMany()
                   .HasForeignKey(e => e.DepartmentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Role)
                   .WithMany()
                   .HasForeignKey(e => e.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
