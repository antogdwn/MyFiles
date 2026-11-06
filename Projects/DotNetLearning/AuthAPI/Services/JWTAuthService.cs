using AuthAPI.DTOs;
using AuthAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthAPI.Services
{
    public class JWTAuthService : IJWTAuthService
    {
        private readonly IConfiguration _configuration;
        public JWTAuthService(IConfiguration configuration) {
            _configuration = configuration;
        
        }
        public string GenerateToken(ApplicationUser user)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, user.Id), new Claim(ClaimTypes.Email, user.Email!) };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials:credentials


                );

            return  new JwtSecurityTokenHandler().WriteToken(token); 
        }



    } 
}

