using System.ComponentModel.DataAnnotations;

namespace ManolaPharm.Application.DTOs.Finance
{
    public class ChartOfAccountUpdateDto
    {
        [Required, MaxLength(150)]
        public string AccountName { get; set; }

        [Required, MaxLength(50)]
        public string AccountType { get; set; }

        [MaxLength(50)]
        public string AccountCategory { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
