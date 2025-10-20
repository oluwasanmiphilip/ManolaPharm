using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManolaPharm.Domain.Entities.Product
{
    /// <summary>
    /// Represents a pharmaceutical product in the ManolaPharm inventory.
    /// </summary>
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Category { get; set; }

        [MaxLength(150)]
        public string Manufacturer { get; set; }

        [MaxLength(100)]
        public string BatchNumber { get; set; }

        public DateTime ExpiryDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [Range(1, 1000)]
        public int QuantityPerPack { get; set; }

        [Range(0, 1000)]
        public int ReorderLevel { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
