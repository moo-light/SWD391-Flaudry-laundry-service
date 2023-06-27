using Application.ViewModels.OrderInBatchs;
using Application.ViewModels.Sessions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Batch
{
    public class BatchResponseDTO : BatchRequestDTO
    {
        public Guid? BatchId { get; set; }
        public Driver? Driver { get; set; }
        public ICollection<SessionResponseDTO> sessionResponses { get; set; } = null;
        public ICollection<OrderInBatchResponseDTO> orderInBatchResponses { get; set; } = null;

    }
}
