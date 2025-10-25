using System;

namespace ManolaPharm.Application.DTOs.Finance
{
    public class FixedAssetDto
    {
        public Guid Id { get; set; }
        public string AssetName { get; set; }
        public string AssetCode { get; set; }
        public string Category { get; set; }
        public decimal Cost { get; set; }
        public decimal AccumulatedDepreciation { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime? DisposalDate { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public string DepreciationMethod { get; set; }
        public decimal ResidualValue { get; set; }
        public int UsefulLifeYears { get; set; }
        public bool IsActive { get; set; }
    }

    

    
}
