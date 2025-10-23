using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManolaPharm.Domain.Entities.Finance
{
    /// <summary>
    /// Represents line items for debit and credit entries linked to a journal entry.
    /// </summary>
    public class JournalEntryDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid JournalEntryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string AccountName { get; set; }

        [Required]
        [MaxLength(50)]
        public string AccountCode { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Debit { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Credit { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

        // Navigation property
        [ForeignKey(nameof(JournalEntryId))]
        public JournalEntry JournalEntry { get; set; }
    }
}
