﻿using Domain.Entitiess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public partial class BaseUser : BaseEntity
{

    public string? FullName { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public string? PasswordHash { get; set; } 
    [Phone]
    public string? PhoneNumber { get; set; }
}
