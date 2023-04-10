using Domain.Entities.DomainEntities;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Account : BaseEntity
{
    public string? Username { get; set; }

    public string? Password { get; set; }

    public bool IsAdmin { get; set; }

    public string? Fullname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public double? Birthday { get; set; }

    public string? Avatar { get; set; }

    public string? Token { get; set; }

    public double? ExpiredDate { get; set; }

    public int? Gender { get; set; }

    public int? LevelId { get; set; }

    public decimal? Wallet { get; set; }

    public Guid? SalerId { get; set; }

    public Guid? OrderingId { get; set; }

    public decimal? Currency { get; set; }

    public Guid? Cnwarehouse { get; set; }

    public Guid? Vnwarehouse { get; set; }

    public Guid? ShippingType { get; set; }

    public decimal? FeeBuyPro { get; set; }

    public decimal? FeeDeposit { get; set; }

    public decimal? FeeWeight { get; set; }

    public decimal? FeeVolume { get; set; }

    public decimal TransactionMoney { get; set; }

    public double? DateUpLevel { get; set; }

    public string? OneSignalPlayerId { get; set; }

    public Guid? RoleId { get; set; }

    public int? RoleNumberId { get; set; }

    public Guid? Apikey { get; set; }

    public Guid? Apisecret { get; set; }
}
