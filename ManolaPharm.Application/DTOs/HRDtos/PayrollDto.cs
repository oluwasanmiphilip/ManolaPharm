using System;

namespace ManolaPharm.Application.DTOs.HRDtos
{
    public class PayrollDto
    {
        public Guid EmployeeId { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deductions { get; set; }
        public DateTime PayrollDate { get; set; }
        public decimal NetPay { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
