using Domain.Entities.DomainEntities;using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class FeeBuyProduct: BaseEntity
{
    

    

    

    

    

    

    

    public decimal? PriceFrom { get; set; }

    public decimal? PriceTo { get; set; }

    public decimal? Percent { get; set; }
}
