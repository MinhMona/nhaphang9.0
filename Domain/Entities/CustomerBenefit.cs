﻿using Domain.Entities.DomainEntities;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class CustomerBenefit : BaseEntity
{
    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public int? Position { get; set; }

    public string? Image { get; set; }

    public string? Link { get; set; }

    public int? Type { get; set; }
}
