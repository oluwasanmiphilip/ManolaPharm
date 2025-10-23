using System.ComponentModel.DataAnnotations;

namespace ManolaPharm.Application.DTOs.Finance
{
    public class JournalEntryDetailUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string AccountName { get; set; }

        [Required]
        [MaxLength(50)]
        public string AccountCode { get; set; }

        public decimal Debit { get; set; }

        public decimal Credit { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
