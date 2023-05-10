using Domain.Entities.DomainEntities;using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class OrderShopTemp
: BaseEntity
{
    

    

    

    

    

    

    

    public Guid? Uid { get; set; }

    public string? ShopId { get; set; }

    public string? ShopName { get; set; }

    public double? Currency { get; set; }

    public string? Link { get; set; }

    public int? MinimumQuantity { get; set; }

    public string? SellerId { get; set; }

    public string? ItemId { get; set; }

    public string? Site { get; set; }

    public string? Title { get; set; }

    public string? WangWang { get; set; }

    public string? PriceStep { get; set; }

    public string? Tool { get; set; }

    public string? VersionTool { get; set; }
}
