using Application.ViewModels.Batch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Drivers
{
    public class DriverResponseDTO
    {
        public ICollection<BatchResponseDTO> BatchResponses { get; set; }
    }
}
