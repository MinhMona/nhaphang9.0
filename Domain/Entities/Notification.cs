using Domain.Entities.DomainEntities;using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Notification: BaseEntity
{
    

    public string? Url { get; set; }

    public DateTime? Created { get; set; }

    

    public DateTime? Updated { get; set; }

    

    public bool Deleted { get; set; }

    public bool Active { get; set; }

    public bool? IsRead { get; set; }

    public string? NotificationContent { get; set; }

    public Guid? RoleId { get; set; }

    public Guid? MainOrderId { get; set; }

    public bool? OfEmployee { get; set; }

    public int? TagIndex { get; set; }

    public Guid? Uid { get; set; }
}
