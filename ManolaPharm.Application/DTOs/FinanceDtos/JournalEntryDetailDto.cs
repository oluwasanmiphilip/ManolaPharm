using System;

namespace ManolaPharm.Application.DTOs.Finance
{
    public class JournalEntryDetailDto
    {
        public string ReferenceNumber { get; set; }
        public DateTime EntryDate { get; set; }
        public string AccountCode { get; set; }
        public string Description { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string TransactionType { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
