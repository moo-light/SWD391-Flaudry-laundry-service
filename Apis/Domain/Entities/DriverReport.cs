using Domain.Entitiess;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class DriverReport:BaseEntity
{

    public Guid? UserId { get; set; }

    public string? Reason { get; set; } 
    public string? Status { get; set; } 

    public virtual User? User { get; set; } 
}
