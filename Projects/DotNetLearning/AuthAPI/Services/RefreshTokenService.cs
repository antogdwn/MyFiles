using AuthAPI.Data;
using AuthAPI.DTOs;
using AuthAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace AuthAPI.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public RefreshTokenService(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
        }
        public string RefreshTokenAsync()
        {
            string randomNumber = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

            return randomNumber;
        }

        public  string HashToken(string refreshToken)
        {
            var bytes = Encoding.UTF8.GetBytes(refreshToken);
            var hash = SHA256.HashData(bytes);

            return Convert.ToHexString(hash);
        }

        public async Task<RefreshToken> ValidatedToken(string refreshToken)
        {
           var token = await _applicationDbContext.RefreshTokens.FirstOrDefaultAsync(x => x.TokenHash.Equals(refreshToken));
            if(!token.IsActive || token ==null)
            {
                throw new Exception("Login again");
            }
            return token;

        }
        public async Task SaveToken(string refreshtoken, ApplicationUser user)
        {
            var token = await _applicationDbContext.RefreshTokens.FirstOrDefaultAsync(x => x.UserId==user.Id);
            if (token == null)
            {
                token = new RefreshToken
                {
                    TokenHash = refreshtoken,
                    UserId = user.Id,
                    CreatedAtUtc = DateTime.Now,
                    ExpiresAtUtc = DateTime.Now.AddDays(7), // hardcoding day
                };

                await _applicationDbContext.RefreshTokens.AddAsync(token);
            }
            else
            {
                token.TokenHash = refreshtoken;
               // token.UserId = user.Id;
                token.CreatedAtUtc = DateTime.Now;
                token.ExpiresAtUtc = DateTime.Now.AddDays(7); // hardcoding day
                
                // res = await _applicationDbContext.RefreshTokens.FirstOrDefaultAsync()
                _applicationDbContext.RefreshTokens.Update(token);

            }
            await _applicationDbContext.SaveChangesAsync();

        }
    }
}
