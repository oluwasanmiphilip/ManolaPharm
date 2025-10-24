using System;

namespace ManolaPharm.Application.DTOs.Finance.TrialBalanceDtos
{
    public class TrialBalanceResponseDto
    {
        public string AccountName { get; set; }
        public string AccountCode { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public bool IsActive { get; set; }
    }
}
