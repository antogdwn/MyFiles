using System.ComponentModel.DataAnnotations;

namespace AuthAPI.DTOs
{
    public sealed record LoginResponseDTO
    {
        [Required]
        public string Token { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime ExpiresAt { get; set; }


    }

}
