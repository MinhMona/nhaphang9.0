using Domain.Entities.DomainEntities;using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class ContactU: BaseEntity
{
    

    

    

    

    

    

    

    public string? Fullname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? Description { get; set; }

    public int? Status { get; set; }
}
