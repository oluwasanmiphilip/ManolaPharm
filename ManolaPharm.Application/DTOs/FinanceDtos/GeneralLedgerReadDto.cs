using System;

namespace ManolaPharm.Application.DTOs.FinanceDtos
{
    public class GeneralLedgerReadDto
    {
        public string AccountName { get; set; }
        public string AccountCode { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
