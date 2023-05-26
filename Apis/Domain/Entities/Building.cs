using Domain.Entitiess;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Building:BaseEntity
{

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
