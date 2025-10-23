using System;

namespace ManolaPharm.Application.DTOs.FinanceDtos
{
    public class JournalEntryDto
    {
        public string EntryNumber { get; set; }
        public DateTime EntryDate { get; set; }
        public string AccountName { get; set; }
        public string AccountCode { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
