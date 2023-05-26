using Domain.Entitiess;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class StoreReport : BaseEntity
{

    public Guid StoreId { get; set; }

    public Guid ServiceId { get; set; }

    public string ReasonReport { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
