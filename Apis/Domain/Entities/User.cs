using Domain.Entitiess;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class User : BaseEntity
{

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public Guid RoleId { get; set; }

    public virtual ICollection<Batch> Batches { get; } = new List<Batch>();

    public virtual ICollection<DriverReport> DriverReports { get; } = new List<DriverReport>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Store> Stores { get; } = new List<Store>();
}
