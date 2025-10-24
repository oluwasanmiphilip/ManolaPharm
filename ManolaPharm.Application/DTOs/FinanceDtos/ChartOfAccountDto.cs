using System;

namespace ManolaPharm.Application.DTOs.Finance
{
    public class ChartOfAccountDto
    {
        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public string AccountCategory { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
