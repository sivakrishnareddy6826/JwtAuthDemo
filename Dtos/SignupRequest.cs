using System.ComponentModel.DataAnnotations;

namespace JwtAuthDemo.Dtos
{
    public class SignupRequest
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
