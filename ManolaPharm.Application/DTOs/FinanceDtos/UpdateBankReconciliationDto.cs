using System;
using System.ComponentModel.DataAnnotations;

namespace ManolaPharm.Application.DTOs.Finance
{
    public class UpdateBankReconciliationDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public decimal BankStatementBalance { get; set; }

        [Required]
        public decimal BookBalance { get; set; }

        public decimal OutstandingDeposits { get; set; }
        public decimal OutstandingPayments { get; set; }

        [MaxLength(250)]
        public string Remarks { get; set; }

        public bool IsReconciled { get; set; }
        public bool IsActive { get; set; }
    }
}
