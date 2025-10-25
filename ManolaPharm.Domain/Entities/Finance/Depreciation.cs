using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManolaPharm.Domain.Entities.Finance
{
    public class Depreciation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid FixedAssetId { get; set; }

        [ForeignKey(nameof(FixedAssetId))]
        public FixedAsset FixedAsset { get; set; }

        [Required]
        public DateTime DepreciationDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DepreciationAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal AccumulatedDepreciation { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal BookValue { get; set; }

        [MaxLength(250)]
        public string Remarks { get; set; }

        public bool IsPosted { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
