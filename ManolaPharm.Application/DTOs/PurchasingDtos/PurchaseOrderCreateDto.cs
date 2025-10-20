using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManolaPharm.Application.DTOs.PurchasingDtos
{
    public class PurchaseOrderCreateDto
    {
        public Guid SupplierId { get; set; }
        public Guid WarehouseId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Remarks { get; set; }
    }
}
