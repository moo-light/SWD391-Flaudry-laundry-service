using Domain.Entitiess;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Package : BaseEntity
{

    public Guid OrderId { get; set; }

    public Guid ServiceId { get; set; }

    public decimal WeightKg { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual Order PackageNavigation { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();

    public virtual Service Service { get; set; } = null!;
}
