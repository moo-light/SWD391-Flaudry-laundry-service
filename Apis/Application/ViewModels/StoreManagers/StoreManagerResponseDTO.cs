using Application.ViewModels.Stores;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.StoreManagers
{
    public class StoreManagerResponseDTO : StoreManagerRequestDTO
    {
        public Guid? StoreManagerId { get; set; }
        public Guid? StoreId { get; set; }
        public StoreResponseDTO? Store { get; set; }
    }
}
