namespace ManolaPharm.Application.DTOs.FinanceDtos
{
    public class AccountsPayableDto
    {
        public Guid Id { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public decimal AmountOwed { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }

   
}
