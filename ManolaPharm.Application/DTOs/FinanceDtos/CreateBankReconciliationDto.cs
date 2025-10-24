using System;
using System.ComponentModel.DataAnnotations;

namespace ManolaPharm.Application.DTOs.Finance
{
    public class CreateBankReconciliationDto
    {
        [Required, MaxLength(100)]
        public string AccountNumber { get; set; }

        [Required, MaxLength(100)]
        public string BankName { get; set; }

        [Required]
        public DateTime StatementDate { get; set; }

        [Required]
        public decimal BankStatementBalance { get; set; }

        [Required]
        public decimal BookBalance { get; set; }

        public decimal OutstandingDeposits { get; set; }
        public decimal OutstandingPayments { get; set; }

        [MaxLength(250)]
        public string Remarks { get; set; }
    }
}
