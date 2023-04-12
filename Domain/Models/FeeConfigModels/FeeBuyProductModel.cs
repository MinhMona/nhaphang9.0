using Domain.Models.DomainModels;
using System;
using System.Collections.Generic;

namespace Domain.Models.FeeConfigModels;

public class FeeBuyProductModel : BaseModel
{
    public decimal? PriceFrom { get; set; }

    public decimal? PriceTo { get; set; }

    public decimal? Percent { get; set; }
}
