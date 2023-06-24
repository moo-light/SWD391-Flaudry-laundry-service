using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.FilterModels
{
    public class PaymentFilteringModel : BaseFilterringModel
    {
        public string?[]? PaymentMethod { get; set; }
        public string?[]? Amount { get; set; }
        public string?[]? Status { get; set; }
    }
}
