using Domain.Entities.DomainEntities;using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class WalletHistory: BaseEntity
{
    

    

    

    

    

    

    

    public Guid? Uid { get; set; }

    public decimal? Price { get; set; }

    public decimal? Wallet { get; set; }

    public string? Content { get; set; }

    public int? Type { get; set; }
}
