using Domain.Entities.DomainEntities;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Vnwarehouse : BaseEntity
{
    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }
}
