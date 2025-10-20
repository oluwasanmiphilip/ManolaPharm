using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ManolaPharm.Domain.Entities.Product;

namespace ManolaPharm.Domain.Entities.Inventory
{
    /// <summary>
    /// Represents stock and cost tracking for each product and batch.
    /// </summary>
    public class Inventory
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product.Product Product { get; set; }

        [Required]
        public int QuantityOnHand { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CostPrice { get; set; }

        [MaxLength(150)]
        public string Location { get; set; }

        [MaxLength(100)]
        public string BatchNumber { get; set; }

        public DateTime ExpiryDate { get; set; }

        public bool LotTrackingEnabled { get; set; }

        public DateTime LastRestocked { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
