using Domain.Entities.DomainEntities;using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class NotificationSetting: BaseEntity
{
    

    public bool IsEmailAdmin { get; set; }

    public bool IsEmailUser { get; set; }

    public DateTime? Created { get; set; }

    

    public DateTime? Updated { get; set; }

    

    public bool Deleted { get; set; }

    public bool Active { get; set; }

    public string? Code { get; set; }

    public int NotifyTitleId { get; set; }
}
