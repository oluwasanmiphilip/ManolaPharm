using System;

namespace ManolaPharm.Application.DTOs.AuthDtos
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }
    }
}
