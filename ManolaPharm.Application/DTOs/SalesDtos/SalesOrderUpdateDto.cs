using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManolaPharm.Application.DTOs.SalesDtos
{
    namespace ManolaPharm.Application.DTOs.SalesDtos
    {
        public class SalesOrderUpdateDto
        {
            
            public DateTime? DeliveryDate { get; set; }
            public string Status { get; set; }
            public string Remarks { get; set; }
            public bool IsActive { get; set; }
            
        }
    }
}
