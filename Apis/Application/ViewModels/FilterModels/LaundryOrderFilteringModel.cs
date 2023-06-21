using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.FilterModels
{
    public class LaundryOrderFilteringModel : BaseFilterringModel
    {
        public Guid?[]? CustomerId { get; set; } 
        public Guid?[]? StoreId { get; set; } 
        public Guid?[]? BuildingId { get; set; } 
        public Guid?[]? OrderInBatchId { get; set; } 
        public string?[]? Note { get; set; } 
    }
}
