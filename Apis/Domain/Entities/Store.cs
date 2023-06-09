using Domain.Entitiess;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Store : BaseEntity
{

    public string? Name { get; set; } 

    public string? Address { get; set; } 
    public virtual ICollection<LaundryOrder> Orders { get; } = new List<LaundryOrder>();
    public virtual ICollection<Service> Services { get; } = new List<Service>();

}
