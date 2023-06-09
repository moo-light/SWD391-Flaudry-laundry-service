using Domain.Entitiess;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderInBatch : BaseEntity
    {
        public Guid? BatchId { get; set; } = null;
        public Guid? OrderId { get; set; } = null;
        [EnumDataType(typeof(OrderInBatchStatus))]
        public string? Status { get; set; }

        public virtual Batch? Batch { get; set; }
        public virtual LaundryOrder? Order { get; set; }
    }
}
