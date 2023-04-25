using Domain.Entities.DomainEntities;using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class NotificationSettingDetail: BaseEntity
{
    

    public Guid? RoleId { get; set; }

    public bool? IsNotify { get; set; }

    public DateTime? Created { get; set; }

    

    public DateTime? Updated { get; set; }

    

    public bool Deleted { get; set; }

    public bool Active { get; set; }

    public Guid? NotificationSettingId { get; set; }
}
