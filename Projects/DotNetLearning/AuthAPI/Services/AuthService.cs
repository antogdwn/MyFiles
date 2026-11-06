using AuthAPI.Data;
using AuthAPI.DTOs;
using AuthAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJWTAuthService _JWTauthService;
        private readonly ApplicationDbContext _appdbContext;
        private readonly IConfiguration _configuration;
        private readonly IRefreshTokenService _refreshTokenService;

        public AuthService(IJWTAuthService JWTauthService, ApplicationDbContext appdbContext, IConfiguration configuration, IRefreshTokenService refreshTokenService)
        {
            _JWTauthService = JWTauthService;
            _appdbContext = appdbContext;
            _configuration = configuration;
            _refreshTokenService = refreshTokenService;
        }
        public async Task<LoginResponseDTO> Login(LoginRequestDTO requestDTO)
        {
            if (requestDTO == null) throw new ArgumentNullException(nameof(requestDTO));

            var user = await _appdbContext.Users.FirstOrDefaultAsync(x => x.Email == requestDTO.Email);

            if (user == null)
            {
                throw new ArgumentNullException("user not found");
            }

            var token = _JWTauthService.GenerateToken(user);

            
            var generatedToken = _refreshTokenService.RefreshTokenAsync();
            var hashToken = _refreshTokenService.HashToken(generatedToken);

            await _refreshTokenService.SaveToken(hashToken, user);

            return new LoginResponseDTO { Token = token, RefreshToken = hashToken, ExpiresAt = DateTime.Now.AddMinutes(int.Parse(_configuration["Jwt:ExpiryMinutes"]!)) };
        }

        public async Task<LoginResponseDTO> RefreshTokenAsync(string refreshtoken)
        {
            //validate the current token active ?
            // get the user who it is assigned to 
            //generate the new token and update the db 


            var currentToken = await _refreshTokenService.ValidatedToken(refreshtoken) ?? throw new Exception("Token doesnt exist or expired, please login again");

            var user = await _appdbContext.Users.SingleOrDefaultAsync(x => x.Id == currentToken.UserId) ?? throw new Exception("User doesnt exist");


            var token = _JWTauthService.GenerateToken(user);

            return new LoginResponseDTO { Token = token, RefreshToken = currentToken.TokenHash, ExpiresAt = DateTime.Now.AddMinutes(int.Parse(_configuration["Jwt:ExpiryMinutes"]!)) };
        }
    }

}

