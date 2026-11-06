using AuthAPI.DTOs;
using AuthAPI.Models;

namespace AuthAPI.Services
{
    public interface IJWTAuthService
    {
        string GenerateToken(ApplicationUser user);

    }
}
