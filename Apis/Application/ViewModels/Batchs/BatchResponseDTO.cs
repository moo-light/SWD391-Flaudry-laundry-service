using Application.ViewModels.OrderInBatch;
using Application.ViewModels.BatchOfBuildings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Batchs
{
    public class BatchResponseDTO : BatchRequestDTO
    {
        public Guid? BatchId { get; set; }
        //public Driver? Driver { get; set; }
        public ICollection<OrderInBatchResponseDTO> orderInBatchResponses { get; set; } = null;

    }
}
