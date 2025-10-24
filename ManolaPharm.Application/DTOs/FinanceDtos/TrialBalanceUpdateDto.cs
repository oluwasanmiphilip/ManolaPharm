using System;

namespace ManolaPharm.Application.DTOs.Finance.TrialBalanceDtos
{
    public class TrialBalanceUpdateDto
    {
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public DateTime PeriodEnd { get; set; }
        public bool IsActive { get; set; }
    }
}
