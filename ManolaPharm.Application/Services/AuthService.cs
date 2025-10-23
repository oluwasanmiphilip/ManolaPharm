using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ManolaPharm.Application.DTOs.AuthDtos;
using ManolaPharm.Application.DTOs.UserDtos;
using ManolaPharm.Domain.Entities.Users;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ManolaPharm.Application.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // Validate credentials and return token response or null
        public async Task<AuthResponseDto?> AuthenticateAsync(LoginDto dto)
        {
            // Find user by username OR email (case-insensitive)
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u =>
                    u.Username.ToLower() == dto.UsernameOrEmail.ToLower()
                    || u.Email.ToLower() == dto.UsernameOrEmail.ToLower());

            if (user == null) return null;

            if (!user.IsActive) return null;

            // Verify password (same hashing as UserService.HashPassword)
            var providedHash = HashPassword(dto.Password);
            if (user.PasswordHash != providedHash)
                return null;

            // Generate JWT
            var token = GenerateToken(user);

            return new AuthResponseDto
            {
                Token = token.Token,
                ExpiresAt = token.ExpiresAt,
                Username = user.Username,
                RoleName = user.Role?.Name
            };
        }

        private (string Token, DateTime ExpiresAt) GenerateToken(User user)
        {
            var jwtSection = _config.GetSection("Jwt");
            var key = jwtSection["Key"];    
            var issuer = jwtSection["Issuer"];
            var audience = jwtSection["Audience"];
            var expiresInStr = jwtSection["ExpiresInMinutes"];
            var expiresIn = int.TryParse(expiresInStr, out var minutes) ? minutes : 60;

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role?.Name ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var keyBytes = Encoding.UTF8.GetBytes(key);
            var signingKey = new SymmetricSecurityKey(keyBytes);
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddMinutes(expiresIn);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: signingCredentials);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return (tokenString, expires);
        }

        // Must match the hashing algorithm used when creating users
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
