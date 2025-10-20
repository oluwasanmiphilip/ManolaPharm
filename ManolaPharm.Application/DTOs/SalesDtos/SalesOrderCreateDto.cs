namespace ManolaPharm.Application.DTOs.SalesDtos
{
    public class SalesOrderCreateDto
    {
        public Guid CustomerId { get; set; }
        public Guid WarehouseId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Remarks { get; set; }
    }
}