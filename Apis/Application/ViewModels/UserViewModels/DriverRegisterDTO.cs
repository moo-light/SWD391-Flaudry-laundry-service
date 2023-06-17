using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Application.ViewModels.UserViewModels
{
    public class DriverRegisterDTO
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
    }
}
