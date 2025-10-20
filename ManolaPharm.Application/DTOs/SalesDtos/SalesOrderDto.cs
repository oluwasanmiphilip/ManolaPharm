using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManolaPharm.Application.DTOs.SalesDtos
{
    namespace ManolaPharm.Application.DTOs.SalesDtos
    {
        public class SalesOrderDto
        {
            public string OrderNumber { get; set; }
            public DateTime OrderDate { get; set; }
            public DateTime? DeliveryDate { get; set; }
            public string CustomerName { get; set; }
            public string WarehouseName { get; set; }
            public decimal TotalAmount { get; set; }
            public string Status { get; set; }
            public string Remarks { get; set; }
            public bool IsActive { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime? UpdatedAt { get; set; }
        }
    }
}
