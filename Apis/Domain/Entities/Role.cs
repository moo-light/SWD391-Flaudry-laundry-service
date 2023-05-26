using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Role
{
    public Guid RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public string? RolePermission { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
