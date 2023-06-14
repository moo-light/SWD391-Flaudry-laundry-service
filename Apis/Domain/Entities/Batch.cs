using Domain.Entitiess;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Batch :BaseEntity
{

    public Guid? DriverId { get; set; }
    public Guid? SessionId { get; set; }
    public string? Type { get; set; } 
    public string? Status { get; set; } 
    public virtual Driver? Driver { get; set; }
    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
    public virtual ICollection<OrderInBatch> OrderInBatches { get; set; } = new List<OrderInBatch>();
}
