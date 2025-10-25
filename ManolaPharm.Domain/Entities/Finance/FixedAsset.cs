using System;
using System.ComponentModel.DataAnnotations;

namespace ManolaPharm.Domain.Entities.Finance
{
    public class FixedAsset
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string AssetName { get; set; }

        [Required, MaxLength(50)]
        public string AssetCode { get; set; }

        [Required, MaxLength(100)]
        public string Category { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public decimal AccumulatedDepreciation { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        public DateTime? DisposalDate { get; set; }

        [Required, MaxLength(100)]
        public string Location { get; set; }

        [Required, MaxLength(100)]
        public string Department { get; set; }

        [Required, MaxLength(50)]
        public string DepreciationMethod { get; set; }

        public decimal ResidualValue { get; set; }

        public int UsefulLifeYears { get; set; }

        public bool IsActive { get; set; }
    }
}
