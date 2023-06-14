using Domain.Entitiess;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public partial class Payment : BaseEntity
{
    public Guid? OrderId { get; set; } = null;
    [EnumDataType(typeof(PaymentMethodEnum))]
    public string? PaymentMethod { get; set; }
    public decimal? Amount { get; set; }
    [EnumDataType(typeof(PaymentStatus))]
    public string? Status { get; set; }
    public virtual LaundryOrder? Order { get; set; }
}
