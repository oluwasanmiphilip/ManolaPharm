namespace ManolaPharm.Application.DTOs.FinanceDtos
{
    public class AccountsReceivableCreateDto
    {
        public Guid SalesOrderId { get; set; }
        public decimal AmountDue { get; set; }
        public DateTime DueDate { get; set; }
        public string Remarks { get; set; }
    }
}