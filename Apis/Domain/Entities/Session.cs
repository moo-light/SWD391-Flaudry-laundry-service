using Domain.Entitiess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public partial class Session : BaseEntity
{
    public Guid? BatchId { get; set; }
    public Guid? BuildingId { get; set; }
    public DateTime? StartTime { get; set; }

    //[Compare(nameof(StartTime), ErrorMessage = "End time must be larger than start time.")]
    public DateTime? EndTime { get; set; }
    public virtual Batch? Batch { get; set; } 
    public virtual Building? Building { get; set; }
}
