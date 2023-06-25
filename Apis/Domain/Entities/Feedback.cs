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
    public class Feedback : BaseEntity
    {
        public string Comment { get; set; } = string.Empty;
        public short Rating { get; set; }
        [EnumDataType(typeof(FeedbackStatusEnums))]
        public string Status { get; set; } = string.Empty;
        public Guid? CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public Guid? StoreId { get; set; }
        public virtual Store? Store { get; set; }
    }
}
