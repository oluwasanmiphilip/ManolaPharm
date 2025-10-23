using System;
using System.ComponentModel.DataAnnotations;

namespace ManolaPharm.Application.DTOs.FinanceDtos
{
    public class JournalEntryUpdateDto
    {
        [Required]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string AccountName { get; set; }

        [MaxLength(50)]
        public string AccountCode { get; set; }

        public decimal? Debit { get; set; }

        public decimal? Credit { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }

        public bool? IsActive { get; set; }
    }
}
