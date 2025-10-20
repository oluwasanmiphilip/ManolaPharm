namespace ManolaPharm.Application.DTOs.InventoryDtos
{
    public class InventoryUpdateDto
    {
        public int QuantityOnHand { get; set; }
        public decimal CostPrice { get; set; }
        public string Location { get; set; }
        public string BatchNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool LotTrackingEnabled { get; set; }
        public DateTime LastRestocked { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
