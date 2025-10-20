namespace ManolaPharm.Application.DTOs.FinanceDtos
{

    public class AccountsPayableCreateDto
    {
        public Guid PurchaseOrderId { get; set; }
        public decimal AmountOwed { get; set; }
        public DateTime DueDate { get; set; }
        public string Remarks { get; set; }
    }
}
