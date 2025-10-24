using System;
using System.ComponentModel.DataAnnotations;

namespace ManolaPharm.Application.DTOs.FinanceDtos
{
    public class GeneralLedgerUpdateDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string AccountName { get; set; }

        [Required, MaxLength(50)]
        public string AccountCode { get; set; }

        [Required]
        public decimal Debit { get; set; }

        [Required]
        public decimal Credit { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required, MaxLength(20)]
        public string Status { get; set; }
    }
}
