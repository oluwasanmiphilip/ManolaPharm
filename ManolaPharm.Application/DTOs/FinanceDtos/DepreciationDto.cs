using System;

namespace ManolaPharm.Application.DTOs.Finance
{
    public class DepreciationDto
    {
        public Guid Id { get; set; }
        public Guid FixedAssetId { get; set; }
        public string AssetName { get; set; }
        public DateTime DepreciationDate { get; set; }
        public decimal DepreciationAmount { get; set; }
        public decimal AccumulatedDepreciation { get; set; }
        public decimal BookValue { get; set; }
        public string Remarks { get; set; }
        public bool IsPosted { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    

   
}
