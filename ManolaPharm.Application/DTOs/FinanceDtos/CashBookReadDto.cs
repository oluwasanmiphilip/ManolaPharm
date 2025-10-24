using System;

namespace ManolaPharm.Application.DTOs.Finance
{
    public class CashBookReadDto
    {
        public string TransactionType { get; set; }
        public string ReferenceNo { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ReceivedBy { get; set; }
        public string ApprovedBy { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsReconciled { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
