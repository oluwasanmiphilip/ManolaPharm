using System;
using System.ComponentModel.DataAnnotations;

namespace ManolaPharm.Application.DTOs.Finance
{
    public class CashBookUpdateDto
    {
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [MaxLength(100)]
        public string ApprovedBy { get; set; }

        [MaxLength(250)]
        public string Remarks { get; set; }

        public bool IsReconciled { get; set; }
    }
}
