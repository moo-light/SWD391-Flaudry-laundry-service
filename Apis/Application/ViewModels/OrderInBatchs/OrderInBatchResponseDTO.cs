using Application.ViewModels.Batchs;
using Application.ViewModels.LaundryOrders;
using Application.ViewModels.OrderDetails;
using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.OrderInBatch
{
    public class OrderInBatchResponseDTO : OrderInBatchRequestDTO
    {
        public Guid? OrderInBatchId { get; set; }
        public virtual ICollection<BatchResponseDTO>? Batch { get; set; } = new List<BatchResponseDTO>();
        public virtual ICollection<LaundryOrderResponseDTO>? Order { get; set; } = new List<LaundryOrderResponseDTO>();
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
