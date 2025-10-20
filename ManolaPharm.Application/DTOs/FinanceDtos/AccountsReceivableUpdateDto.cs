namespace ManolaPharm.Application.DTOs.FinanceDtos
{
    public class AccountsReceivableUpdateDto
    {
        public decimal AmountPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
    }
}
