using Application.ViewModels.Customer;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.NewFolder
{
    public class LaundryOrderResponseDTO
    {
        public Guid? CustomerId { get; set; } = null;
        public Guid? StoreId { get; set; } = null;
        public Guid? BuildingId { get; set; } = null;
        public Guid? OrderInBatchId { get; set; } = null;
        public string? Note { get; set; } = null;
        public virtual CustomerResponseDTO? Customer { get; set; }
        public virtual Building? Building { get; set; }
        public virtual Store? Store { get; set; }
    }
}
