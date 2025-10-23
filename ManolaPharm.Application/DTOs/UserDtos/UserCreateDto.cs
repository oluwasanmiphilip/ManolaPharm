using System;
using System.ComponentModel.DataAnnotations;

namespace ManolaPharm.Application.DTOs.UserDtos
{
    public class UserCreateDto
    {
        [Required, MaxLength(100)]
        public string Username { get; set; }

        [Required, MaxLength(150)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string? Phone { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Guid RoleId { get; set; }
    }
}
