namespace ManolaPharm.Application.DTOs.ProductDtos
{
    public class ProductUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Manufacturer { get; set; }
        public string BatchNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal UnitPrice { get; set; }
        public int QuantityPerPack { get; set; }
        public int ReorderLevel { get; set; }
        public bool IsActive { get; set; }
    }
}
