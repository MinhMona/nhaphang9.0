using Domain.Entities.DomainEntities;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Role : BaseEntity
{
    public string? Name { get; set; }
}
