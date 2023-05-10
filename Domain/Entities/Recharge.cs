using Domain.Entities.DomainEntities;using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Recharge: BaseEntity
{
    

    

    

    

    

    

    

    public Guid? Uid { get; set; }

    public Guid? BankId { get; set; }

    public decimal? Amount { get; set; }

    public string? Content { get; set; }

    public int? Status { get; set; }

    public string? Username { get; set; }
}
