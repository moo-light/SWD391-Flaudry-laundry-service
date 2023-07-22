using Domain.CustomValidations;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Batchs
{
    public class BatchRequestDTO
    {
        public Guid? DriverId { get; set; }
        [EnumValidation(typeof(BatchType))]
        public string? Type { get; set; }
        [EnumValidation(typeof(BatchStatus))]
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
        public string? Status { get; set; }
    }
}
