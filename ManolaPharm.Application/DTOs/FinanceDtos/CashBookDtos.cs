using System;
using System.ComponentModel.DataAnnotations;

namespace ManolaPharm.Application.DTOs.Finance
{
    public class CashBookCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string TransactionType { get; set; }

        [Required]
        [MaxLength(150)]
        public string ReferenceNo { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string ReceivedBy { get; set; }

        [MaxLength(100)]
        public string ApprovedBy { get; set; }

        [MaxLength(100)]
        public string PaymentMethod { get; set; }

        [MaxLength(250)]
        public string Remarks { get; set; }
    }
}
