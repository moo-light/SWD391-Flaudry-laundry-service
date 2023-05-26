using Domain.Entitiess;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Payment:BaseEntity
{

    public Guid? PackageId { get; set; }

    public string? Status { get; set; } = string.Empty;

    public virtual Package? Package { get; set; } 
}
