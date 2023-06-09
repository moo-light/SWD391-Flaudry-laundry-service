﻿using Domain.Entitiess;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Domain.Entities;

public partial class Building:BaseEntity
{
    public string? Name { get; set; } 

    public string? Address { get; set; } 

    public virtual ICollection<Session> Sessions { get; } = new List<Session>();
    public virtual ICollection<LaundryOrder> Orders { get; } = new List<LaundryOrder>();
}
