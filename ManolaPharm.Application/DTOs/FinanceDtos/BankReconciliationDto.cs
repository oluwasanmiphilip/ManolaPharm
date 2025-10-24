using System;

namespace ManolaPharm.Application.DTOs.Finance
{
    public class BankReconciliationDto
    {
        public Guid Id { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public DateTime StatementDate { get; set; }
        public decimal BankStatementBalance { get; set; }
        public decimal BookBalance { get; set; }
        public decimal OutstandingDeposits { get; set; }
        public decimal OutstandingPayments { get; set; }
        public string Remarks { get; set; }
        public bool IsReconciled { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
