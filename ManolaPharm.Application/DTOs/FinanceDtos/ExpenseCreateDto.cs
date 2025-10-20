namespace ManolaPharm.Application.DTOs.FinanceDtos
{
    public class ExpenseCreateDto
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string PaidTo { get; set; }
        public string Remarks { get; set; }
    }
}
