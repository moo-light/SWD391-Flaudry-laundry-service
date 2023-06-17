using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.UserViewModels
{
    public class UserLoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
