using Domain.Entities.DomainEntities;using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Bank: BaseEntity
{
    

    

    

    

    

    

    

    public string? BankName { get; set; }

    public string? BankNumber { get; set; }

    public string? BankHolder { get; set; }

    public string? Branch { get; set; }

    public string? Image { get; set; }

    public string? Qrimage { get; set; }
}
