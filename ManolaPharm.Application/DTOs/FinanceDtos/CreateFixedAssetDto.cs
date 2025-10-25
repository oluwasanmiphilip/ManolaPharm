using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManolaPharm.Application.DTOs.FinanceDtos
{
    public class CreateFixedAssetDto
    {
        public string AssetName { get; set; }
        public string AssetCode { get; set; }
        public string Category { get; set; }
        public decimal Cost { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public string DepreciationMethod { get; set; }
        public decimal ResidualValue { get; set; }
        public int UsefulLifeYears { get; set; }
    }
}
