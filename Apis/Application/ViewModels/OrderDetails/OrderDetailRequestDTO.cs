using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.OrderDetails
{
    public class OrderDetailRequestDTO
    {
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public decimal Weight { get; set; }
    }
}