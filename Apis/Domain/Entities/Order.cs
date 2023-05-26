using Domain.Entitiess;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Order : BaseEntity
{

    public Guid? UserId { get; set; }

    public Guid? BuildingId { get; set; }

    public Guid? StoreId { get; set; }

    public Guid? PackageId { get; set; }

    public Guid? PaymentId { get; set; }

    public Guid? BatchId { get; set; }

    public string? DeliveringStatus { get; set; } 

    public decimal? TotalPrice { get; set; }

    public virtual Building? Building { get; set; } 

    public virtual Package? Package { get; set; } 

    public virtual Package? PackageNavigation { get; set; }

    public virtual Store? Store { get; set; }

    public virtual User? User { get; set; } 
}
