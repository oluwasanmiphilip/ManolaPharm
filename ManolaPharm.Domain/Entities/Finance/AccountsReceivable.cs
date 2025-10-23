using ManolaPharm.Domain.Entities.Sales;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManolaPharm.Domain.Entities.Finance
{
    public class AccountsReceivable
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid SalesOrderId { get; set; }

        // Navigation property
        public SalesOrder SalesOrder { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal AmountOwed { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AmountPaid { get; set; } = 0m;

        [Required]
        public DateTime DueDate { get; set; }

        public DateTime? PaymentDate { get; set; }

        [Required, MaxLength(20)]
        public string Status { get; set; } = "Pending";

        [MaxLength(250)]
        public string Remarks { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
