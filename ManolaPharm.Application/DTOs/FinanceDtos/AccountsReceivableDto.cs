namespace ManolaPharm.Application.DTOs.FinanceDtos
{
    public class AccountsReceivableDto
    {
        public Guid Id { get; set; }
        public string SalesOrderNumber { get; set; }
        public decimal AmountDue { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; internal set; }
        public DateTime CreatedAt { get; internal set; }
        public DateTime? UpdatedAt { get; internal set; }
    }
}