using Application.ViewModels.OrderDetails;
using Domain.Entities;

namespace Application.ViewModels.Stores
{
    public class ServiceResponseDTO
    {
        public Guid? ServiceId { get; set; }
        public decimal? PricePerKg { get; set; }
        //public virtual StoreResponseDTO? Store { get; set; }
        //public virtual ICollection<OrderDetailResponseDTO>? OrderDetails { get; set; }
    }
}