using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManolaPharm.Application.DTOs.FinanceDtos
{
    public class CreateDepreciationDto
    {
        public Guid FixedAssetId { get; set; }
        public DateTime DepreciationDate { get; set; }
        public decimal DepreciationAmount { get; set; }
        public string Remarks { get; set; }
    }
}
