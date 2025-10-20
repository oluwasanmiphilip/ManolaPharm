namespace ManolaPharm.Application.DTOs.PurchasingDtos
{
    public class PurchaseOrderUpdateDto
    {
        public Guid Id { get; set; } // For updating the specific record
        public DateTime? ExpectedDeliveryDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
    }
}
