using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManolaPharm.Domain.Entities.Finance
{
    public class GeneralLedger
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string AccountName { get; set; }

        [Required, MaxLength(50)]
        public string AccountCode { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Debit { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Credit { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required, MaxLength(20)]
        public string Status { get; set; } = "Active";

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}
