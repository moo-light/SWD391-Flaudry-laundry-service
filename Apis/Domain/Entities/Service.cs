using Domain.Entitiess;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Service : BaseEntity
{
    public Guid? StoreId { get; set; }

    public decimal? PricePerKg { get; set; }

    public virtual ICollection<Package> Packages { get; } = new List<Package>();

    public virtual Store? Store { get; set; } 

    public virtual ICollection<StoreReport> StoreReports { get; } = new List<StoreReport>();
}
