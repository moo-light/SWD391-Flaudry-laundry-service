using Domain.CustomValidations;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Payments
{
    public class PaymentRequestDTO
    {
        public Guid?  OrderId { get; set; }
        public decimal? Amount { get; set; }
        [EnumValidation(typeof(PaymentMethodEnum))]
        public string? PaymentMethod { get; set; }
        [EnumValidation(typeof(PaymentStatus))]
        public string? Status { get; set; }
    }
}