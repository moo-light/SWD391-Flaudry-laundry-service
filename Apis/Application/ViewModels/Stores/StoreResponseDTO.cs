using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Stores
{
    public class StoreResponseDTO : StoreRequestDTO
    {
        public Guid? StoreId { get; set; }
    }
}
