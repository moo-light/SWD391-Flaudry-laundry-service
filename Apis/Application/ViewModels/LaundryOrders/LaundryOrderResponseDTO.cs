using Application.ViewModels.Buildings;
using Application.ViewModels.Customer;
using Application.ViewModels.OrderDetails;
using Application.ViewModels.OrderInBatch;
using Application.ViewModels.Payments;
using Application.ViewModels.Stores;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.LaundryOrders
{
    public class LaundryOrderResponseDTO : LaundryOrderRequestDTO
    {
        public Guid? OrderId { get; set; }
        //public virtual CustomerResponseDTO? Customer { get; set; }
        //public virtual BuildingResponseDTO? Building { get; set; }
        //public virtual StoreResponseDTO? Store { get; set; }
        //public virtual ICollection<OrderInBatchResponseDTO> OrderInBatches { get; set; } = new List<OrderInBatchResponseDTO>();
        public virtual ICollection<OrderDetailResponseDTO> OrderDetails { get; set; } = new List<OrderDetailResponseDTO>();
        public virtual ICollection<PaymentResponseDTO> Payments { get; set; } = new List<PaymentResponseDTO>();
    }
}
