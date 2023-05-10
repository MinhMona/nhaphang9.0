using Domain.Entities.DomainEntities;using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class FeeCheckProduct: BaseEntity
{
    

    

    

    

    

    

    

    public string? Name { get; set; }

    public int? Type { get; set; }

    public decimal? QuantityFrom { get; set; }

    public decimal? QuantityTo { get; set; }

    public decimal? Price { get; set; }
}
