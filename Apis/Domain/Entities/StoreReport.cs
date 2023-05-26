using Domain.Entitiess;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class StoreReport : BaseEntity
{

    public Guid? StoreId { get; set; }

    public Guid? ServiceId { get; set; }

    public string? ReasonReport { get; set; } 

    public string? Status { get; set; } 

    public virtual Service? Service { get; set; } 

    public virtual Store? Store { get; set; } 
}
