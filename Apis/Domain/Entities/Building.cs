using Domain.Entitiess;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Building:BaseEntity
{

    public string? Name { get; set; } 

    public string? Address { get; set; } 

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
