using ManolaPharm.Domain.Entities.HR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManolaPharm.Persistence.Configurations
{
    public class PayrollConfiguration : IEntityTypeConfiguration<Payroll>
    {
        public void Configure(EntityTypeBuilder<Payroll> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.BasicSalary)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.Allowances)
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Deductions)
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.NetPay)
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.PayrollDate)
                   .IsRequired();

            builder.Property(p => p.IsActive)
                   .HasDefaultValue(true);

            builder.Property(p => p.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()");

            // Configure Employee relationship without shadow FK
            builder.HasOne<Employee>()
                   .WithMany()
                   .HasForeignKey(p => p.EmployeeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
