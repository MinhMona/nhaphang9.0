using Domain.Entities.DomainEntities;using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class OrderTemp: BaseEntity
{
    

    

    

    

    

    

    

    public Guid? OrderShopTempId { get; set; }

    public string? Image { get; set; }

    public double? PriceOrigin { get; set; }

    public double? PricePromotion { get; set; }

    public string? Properties { get; set; }

    public int? Quantity { get; set; }

    public string? SkuId { get; set; }
}
