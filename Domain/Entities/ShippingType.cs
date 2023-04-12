using Domain.Entities.DomainEntities;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ShippingType : BaseEntity
{
    public string? Code { get; set; }

    public string? Name { get; set; }
}
