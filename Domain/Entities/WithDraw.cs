using Domain.Entities.DomainEntities;using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class WithDraw: BaseEntity
{
    

    

    

    

    

    

    

    public Guid? Uid { get; set; }

    public decimal? Amount { get; set; }

    public string? BankNumber { get; set; }

    public string? Bank { get; set; }

    public int? Status { get; set; }

    public string? Username { get; set; }

    public string? Content { get; set; }
}
