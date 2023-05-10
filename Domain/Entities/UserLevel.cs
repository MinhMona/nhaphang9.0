using Domain.Entities.DomainEntities;using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class UserLevel: BaseEntity
{
    

    

    

    

    

    

    

    public string? Name { get; set; }

    public decimal? FeeBuyProDis { get; set; }

    public decimal? FeeShippingDis { get; set; }

    public decimal? MinAccumulate { get; set; }

    public decimal? MaxAccumulate { get; set; }

    public decimal? MinDeposit { get; set; }
}
