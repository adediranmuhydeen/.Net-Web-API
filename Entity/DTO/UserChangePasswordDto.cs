using System.ComponentModel.DataAnnotations;

namespace Entity.DTO
{
    public class UserChangePasswordDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
