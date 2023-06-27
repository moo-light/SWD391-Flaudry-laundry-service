using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.OrderInBatch
{
    public class OrderInBatchRequestDTO
    {
        [EnumDataType(typeof(OrderInBatchStatus))]
        public string? Status { get; set; }
    }
}