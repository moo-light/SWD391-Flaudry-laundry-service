using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.OrderDetails
{
    public class OrderDetailResponseDTO : OrderDetailRequestDTO
    {
        public Guid? OrderDetailId { get; set; }
        public virtual LaundryOrder? Order { get; set; } = null;// Order status = 
        public virtual Service? Service { get; set; } = null;
    }
}
