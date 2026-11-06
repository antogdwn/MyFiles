using System.ComponentModel.DataAnnotations;

namespace AuthAPI.DTOs
{
    public sealed record LoginRequestDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }


    }
}
