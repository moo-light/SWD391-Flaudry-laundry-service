using Application.ViewModels.Batchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Drivers
{
    public class DriverResponseDTO : DriverRequestDTO
    {
        public Guid? DriverId { get; set; }
        //public ICollection<BatchResponseDTO> BatchResponses { get; set; } = null;
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
