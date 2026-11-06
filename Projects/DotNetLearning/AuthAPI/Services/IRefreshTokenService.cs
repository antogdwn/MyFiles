using AuthAPI.DTOs;
using AuthAPI.Models;
using Microsoft.IdentityModel.Tokens.Experimental;

namespace AuthAPI.Services
{
    public interface IRefreshTokenService
    {
        public string RefreshTokenAsync();
         string HashToken(string refreshToken);
        Task<RefreshToken> ValidatedToken(string refreshToken);

        Task SaveToken(string  refreshToken, ApplicationUser user);
    }
}
