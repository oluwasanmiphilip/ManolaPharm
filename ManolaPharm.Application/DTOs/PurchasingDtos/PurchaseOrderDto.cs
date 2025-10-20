namespace ManolaPharm.Application.DTOs.PurchasingDtos
{
    public class PurchaseOrderDto
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public string SupplierName { get; set; }
        public string WarehouseName { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    
}
