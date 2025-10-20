using System;

namespace ManolaPharm.Application.DTOs.HRDtos
{
    public class PayrollUpdateDto
    {
        public decimal BasicSalary { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deductions { get; set; }
        public DateTime PayrollDate { get; set; }
    }
}
