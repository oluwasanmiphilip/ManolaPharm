namespace ManolaPharm.Application.DTOs.WarehouseDtos
{
    public class WarehouseCreateDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Manager { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Capacity { get; set; }
    }
}
