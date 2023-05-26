using Domain.Entitiess;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Batch :BaseEntity
{

    public Guid DriverId { get; set; }

    public string BatchType { get; set; } 

    public Guid? TimeSlotId { get; set; }

    public virtual User Driver { get; set; } = null!;

    public virtual TimeSlot? TimeSlot { get; set; }
}
