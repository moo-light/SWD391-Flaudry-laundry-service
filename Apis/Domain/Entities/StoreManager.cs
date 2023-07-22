using Domain.Entitiess;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class StoreManager : BaseUser
{
    public Guid? StoreId { get; set; }
    public virtual Store? Store { get; set; }
}
