using System;
using System.ComponentModel.DataAnnotations;

namespace ManolaPharm.Application.DTOs.FinanceDtos
{
    public class JournalEntryCreateDto
    {
        [Required, MaxLength(50)]
        public string EntryNumber { get; set; }

        [Required]
        public DateTime EntryDate { get; set; }

        [Required, MaxLength(100)]
        public string AccountName { get; set; }

        [Required, MaxLength(50)]
        public string AccountCode { get; set; }

        [Required]
        public decimal Debit { get; set; }

        [Required]
        public decimal Credit { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }
    }
}
