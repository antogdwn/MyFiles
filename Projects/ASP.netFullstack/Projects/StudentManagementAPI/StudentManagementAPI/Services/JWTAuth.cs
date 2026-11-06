using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentManagementAPI.Services
{
    public class JWTAuth : IJWTAuthservice
    {

        private readonly IConfiguration configuration;

        public JWTAuth(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string GenerateToken(string username)
        {
            var claims = new Claim [] {new Claim (ClaimTypes.Name ,username),new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())};
            var res = configuration["JwtSettings:key"];
            //var issuer = configuration["Issuer"];
            //var audience = configuration["audience"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(res));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["JwtSettings:Issuer"],
                audience: configuration["JwtSettings:audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials:creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
           
        }

        public bool ValidateUser(string username, string password)
        {
            if(username =="Admin" && password =="Password")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
