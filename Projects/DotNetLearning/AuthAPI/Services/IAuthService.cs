using AuthAPI.DTOs;

namespace AuthAPI.Services
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> Login(LoginRequestDTO requestDTO);
        Task<LoginResponseDTO> RefreshTokenAsync(string refreshtoken);
    }
}
