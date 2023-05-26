using Domain.Entitiess;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TimeSlot : BaseEntity
{

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public DateTime Date { get; set; }

    public virtual ICollection<Batch> Batches { get; } = new List<Batch>();
}
