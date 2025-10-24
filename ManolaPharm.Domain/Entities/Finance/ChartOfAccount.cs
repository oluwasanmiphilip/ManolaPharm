using System;
using System.ComponentModel.DataAnnotations;

namespace ManolaPharm.Domain.Entities.Finance
{
    public class ChartOfAccount
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(50)]
        public string AccountCode { get; set; }

        [Required, MaxLength(150)]
        public string AccountName { get; set; }

        [Required, MaxLength(50)]
        public string AccountType { get; set; } // e.g., Asset, Liability, Equity, Revenue, Expense

        [MaxLength(50)]
        public string AccountCategory { get; set; } // e.g., Current Asset, Non-Current Asset
        public decimal Balance { get; set; }

        public bool IsActive { get; set; } = true;

        [MaxLength(250)]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        
    }
}
