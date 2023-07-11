using Application.ViewModels.OrderInBatch;
using Domain.CustomValidations;
using Domain.Entities;
using Domain.Enums;

namespace Application.ViewModels.Batchs
{
    public class BatchRequestDTO_V2
    {
        [EnumValidation(typeof(BatchType))]
        public string? Type { get; set; }
        [EnumValidation(typeof(BatchStatus))]
        public string? Status { get; set; }
        public DateTime? Date { get; set; }
        public ICollection<Guid> OrderIds { get; set; } = new List<Guid>();
    }

}
