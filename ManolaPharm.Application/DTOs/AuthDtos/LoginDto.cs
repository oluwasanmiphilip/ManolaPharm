using System.ComponentModel.DataAnnotations;

namespace ManolaPharm.Application.DTOs.AuthDtos
{
    public class LoginDto
    {
        [Required]
        public string UsernameOrEmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
