using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength  = 4, ErrorMessage = "string must be from 4 to 8 simbols.")]
        public string Password { get; set; }
    }
}