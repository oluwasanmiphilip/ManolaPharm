using System;
using System.ComponentModel.DataAnnotations;

namespace ManolaPharm.Domain.Entities.Finance
{
    public class BankReconciliation
    {
        [Key]
        public Guid Id { get; set; }

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

        public bool IsReconciled { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}
