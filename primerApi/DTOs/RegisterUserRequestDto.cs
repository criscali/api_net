using System.ComponentModel.DataAnnotations;

namespace primerApi.DTOs
{
    public class RegisterUserRequestDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
