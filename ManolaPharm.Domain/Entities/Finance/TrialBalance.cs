using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManolaPharm.Domain.Entities.Finance
{
    public class TrialBalance
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string AccountName { get; set; }

        [Required, MaxLength(50)]
        public string AccountCode { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Debit { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Credit { get; set; }

        [Required]
        public DateTime PeriodStart { get; set; }

        [Required]
        public DateTime PeriodEnd { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
