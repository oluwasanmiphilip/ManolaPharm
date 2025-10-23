using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManolaPharm.Domain.Entities.Finance
{
    /// <summary>
    /// Represents a financial journal entry for debit and credit records.
    /// </summary>
    public class JournalEntry
    {
        public object JournalNumber;

        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(50)]
        public string EntryNumber { get; set; }

        [Required]
        public DateTime EntryDate { get; set; }

        [Required, MaxLength(100)]
        public string AccountName { get; set; }

        [Required, MaxLength(50)]
        public string AccountCode { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Debit { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Credit { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(20)]
        public string Status { get; set; } = "Posted";

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}
