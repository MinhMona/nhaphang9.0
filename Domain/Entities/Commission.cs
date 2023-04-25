using Domain.Entities.DomainEntities;using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Commission: BaseEntity
{
    

    

    

    

    

    

    

    public int? Type { get; set; }

    public Guid? OrderId { get; set; }

    public Guid? StaffId { get; set; }

    public string? StaffName { get; set; }

    public decimal? Percent { get; set; }

    public decimal? ReceivedPrice { get; set; }

    public double? OrderCompleteDate { get; set; }

    public int? Status { get; set; }

    public string? RoleName { get; set; }

    public int? RoleNumberId { get; set; }
}
