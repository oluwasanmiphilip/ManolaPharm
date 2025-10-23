using System;

namespace ManolaPharm.Application.DTOs.UserDtos
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string RoleName { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
