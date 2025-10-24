using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManolaPharm.Domain.Entities.Finance
{
    public class CashBook
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string TransactionType { get; set; } // e.g., "Receipt" or "Payment"

        [Required]
        [MaxLength(150)]
        public string ReferenceNo { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string ReceivedBy { get; set; }

        [MaxLength(100)]
        public string ApprovedBy { get; set; }

        [MaxLength(100)]
        public string PaymentMethod { get; set; } // e.g., "Cash", "Transfer"

        public bool IsReconciled { get; set; } = false;

        [MaxLength(250)]
        public string Remarks { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        [MaxLength(20)]
        public string Status { get; set; } = "Pending";
    }
}
