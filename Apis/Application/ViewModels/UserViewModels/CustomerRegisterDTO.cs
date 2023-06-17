using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Application.ViewModels.UserViewModels
{
    public class CustomerRegisterDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string? FullName { get; set; }
        [EmailAddress]
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string? Email { get; set; }
        [PasswordPropertyText]
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string? Password { get; set; }
        [Phone]
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 10)]
        public string? Address { get; set; }
    }
}
