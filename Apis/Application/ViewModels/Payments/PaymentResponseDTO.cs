using Application.ViewModels.LaundryOrders;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.ViewModels.Payments
{
    public class PaymentResponseDTO : PaymentRequestDTO
    {
        public Guid? PaymentId { get; set; }
        [JsonIgnore]
        public virtual LaundryOrderResponseDTO? Order { get; set; } = null;
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
