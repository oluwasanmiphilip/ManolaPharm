using System;

namespace ManolaPharm.Application.DTOs.Finance.AccountsReceivableDtos
{
    public class AccountsReceivableReadDto
    {
        public Guid Id { get; set; }
        public Guid SalesOrderId { get; set; }
        public decimal AmountOwed { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
