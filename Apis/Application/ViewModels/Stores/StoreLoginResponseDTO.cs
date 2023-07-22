using Application.ViewModels.Feedbacks;
using Application.ViewModels.LaundryOrders;
using Application.ViewModels.UserViewModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Stores
{
    public class StoreLoginResponseDTO : UserLoginDTOResponse
    {
        public Guid? StoreId { get; set; }
        
    }
}