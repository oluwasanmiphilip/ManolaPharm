using System;
using System.ComponentModel.DataAnnotations;

namespace ManolaPharm.Application.DTOs.Finance.AccountsReceivableDtos
{
    public class AccountsReceivableCreateDto
    {
        [Required]
        public Guid SalesOrderId { get; set; }

        [Required]
        public decimal AmountOwed { get; set; }

        public decimal AmountPaid { get; set; } = 0m;

        [Required]
        public DateTime DueDate { get; set; }

        [MaxLength(250)]
        public string Remarks { get; set; }
    }
}
