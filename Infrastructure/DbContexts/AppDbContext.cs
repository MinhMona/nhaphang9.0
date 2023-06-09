﻿using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts;

public partial class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Bank> Banks { get; set; }

    public virtual DbSet<Cnwarehouse> Cnwarehouses { get; set; }

    public virtual DbSet<Commission> Commissions { get; set; }

    public virtual DbSet<ContactU> ContactUs { get; set; }

    public virtual DbSet<CustomerBenefit> CustomerBenefits { get; set; }

    public virtual DbSet<CustomerTalk> CustomerTalks { get; set; }

    public virtual DbSet<FeeBuyProduct> FeeBuyProducts { get; set; }

    public virtual DbSet<FeeCheckProduct> FeeCheckProducts { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationSetting> NotificationSettings { get; set; }

    public virtual DbSet<NotificationSettingDetail> NotificationSettingDetails { get; set; }

    public virtual DbSet<OrderShopTemp> OrderShopTemps { get; set; }

    public virtual DbSet<OrderTemp> OrderTemps { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostCategory> PostCategories { get; set; }

    public virtual DbSet<Recharge> Recharges { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ShippingType> ShippingTypes { get; set; }

    public virtual DbSet<Step> Steps { get; set; }

    public virtual DbSet<UserLevel> UserLevels { get; set; }

    public virtual DbSet<Vnwarehouse> Vnwarehouses { get; set; }

    public virtual DbSet<VolumeFee> VolumeFees { get; set; }

    public virtual DbSet<WalletHistory> WalletHistories { get; set; }

    public virtual DbSet<WebConfiguration> WebConfigurations { get; set; }

    public virtual DbSet<WeightFee> WeightFees { get; set; }

    public virtual DbSet<WithDraw> WithDraws { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("Account");

            entity.HasIndex(e => e.Username, "username_account").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Address).HasMaxLength(1000);
            entity.Property(e => e.Apikey)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("APIKey");
            entity.Property(e => e.Apisecret)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("APISecret");
            entity.Property(e => e.Cnwarehouse).HasColumnName("CNWarehouse");
            entity.Property(e => e.Currency).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.FeeBuyPro).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.FeeDeposit).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.FeeVolume).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.FeeWeight).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Fullname).HasMaxLength(1000);
            entity.Property(e => e.OneSignalPlayerId).HasColumnName("OneSignalPlayerID");
            entity.Property(e => e.Password).HasMaxLength(1000);
            entity.Property(e => e.TransactionMoney).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Vnwarehouse).HasColumnName("VNWarehouse");
            entity.Property(e => e.Wallet).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Bank>(entity =>
        {
            entity.ToTable("Bank");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Qrimage).HasColumnName("QRImage");
        });

        modelBuilder.Entity<Cnwarehouse>(entity =>
        {
            entity.ToTable("CNWarehouse");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Commission>(entity =>
        {
            entity.ToTable("Commission");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Percent).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ReceivedPrice).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<ContactU>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Fullname).HasMaxLength(1000);
        });

        modelBuilder.Entity<CustomerBenefit>(entity =>
        {
            entity.ToTable("CustomerBenefit");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(1000);
        });

        modelBuilder.Entity<CustomerTalk>(entity =>
        {
            entity.ToTable("CustomerTalk");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(1000);
        });

        modelBuilder.Entity<FeeBuyProduct>(entity =>
        {
            entity.ToTable("FeeBuyProduct");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Percent).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PriceFrom).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PriceTo).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<FeeCheckProduct>(entity =>
        {
            entity.ToTable("FeeCheckProduct");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.QuantityFrom).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.QuantityTo).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("Menu");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(1000);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Notification");

            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.IsRead)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.OfEmployee)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Uid).HasColumnName("UID");
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
        });

        modelBuilder.Entity<NotificationSetting>(entity =>
        {
            entity.ToTable("NotificationSetting");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
        });

        modelBuilder.Entity<NotificationSettingDetail>(entity =>
        {
            entity.ToTable("NotificationSettingDetail");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
        });

        modelBuilder.Entity<OrderShopTemp>(entity =>
        {
            entity.ToTable("OrderShopTemp");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.SellerId).HasColumnName("SellerID");
            entity.Property(e => e.ShopId).HasColumnName("ShopID");
            entity.Property(e => e.Site).HasMaxLength(100);
            entity.Property(e => e.Uid).HasColumnName("UId");
        });

        modelBuilder.Entity<OrderTemp>(entity =>
        {
            entity.ToTable("OrderTemp");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.SkuId).HasColumnName("SkuID");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("Post");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Ogdescription).HasColumnName("OGDescription");
            entity.Property(e => e.OgfacebookDescription).HasColumnName("OGFacebookDescription");
            entity.Property(e => e.OgfacebookImage).HasColumnName("OGFacebookImage");
            entity.Property(e => e.OgfacebookTitle).HasColumnName("OGFacebookTitle");
            entity.Property(e => e.Ogtitle).HasColumnName("OGTitle");
            entity.Property(e => e.OgtwitterDescription).HasColumnName("OGTwitterDescription");
            entity.Property(e => e.OgtwitterImage).HasColumnName("OGTwitterImage");
            entity.Property(e => e.OgtwitterTitle).HasColumnName("OGTwitterTitle");
            entity.Property(e => e.Ogurl).HasColumnName("OGUrl");
            entity.Property(e => e.Title).HasMaxLength(1000);
        });

        modelBuilder.Entity<PostCategory>(entity =>
        {
            entity.ToTable("PostCategory");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Ogdescription).HasColumnName("OGDescription");
            entity.Property(e => e.OgfacebookDescription).HasColumnName("OGFacebookDescription");
            entity.Property(e => e.OgfacebookImage).HasColumnName("OGFacebookImage");
            entity.Property(e => e.OgfacebookTitle).HasColumnName("OGFacebookTitle");
            entity.Property(e => e.Ogtitle).HasColumnName("OGTitle");
            entity.Property(e => e.OgtwitterDescription).HasColumnName("OGTwitterDescription");
            entity.Property(e => e.OgtwitterImage).HasColumnName("OGTwitterImage");
            entity.Property(e => e.OgtwitterTitle).HasColumnName("OGTwitterTitle");
            entity.Property(e => e.Ogurl).HasColumnName("OGUrl");
            entity.Property(e => e.Title).HasMaxLength(1000);
        });

        modelBuilder.Entity<Recharge>(entity =>
        {
            entity.ToTable("Recharge");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Uid).HasColumnName("UId");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(1000);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Service");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(1000);
        });

        modelBuilder.Entity<ShippingType>(entity =>
        {
            entity.ToTable("ShippingType");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Step>(entity =>
        {
            entity.ToTable("Step");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(1000);
        });

        modelBuilder.Entity<UserLevel>(entity =>
        {
            entity.ToTable("UserLevel");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.FeeBuyProDis).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FeeShippingDis).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaxAccumulate).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.MinAccumulate).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.MinDeposit).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Vnwarehouse>(entity =>
        {
            entity.ToTable("VNWarehouse");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<VolumeFee>(entity =>
        {
            entity.ToTable("VolumeFee");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CnwarehouseId).HasColumnName("CNWarehouseId");
            entity.Property(e => e.CnwarehouseName).HasColumnName("CNWarehouseName");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PriceReal).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.VnwarehouseId).HasColumnName("VNWarehouseId");
            entity.Property(e => e.VnwarehouseName).HasColumnName("VNWarehouseName");
            entity.Property(e => e.VolumeFrom).HasColumnType("decimal(18, 5)");
            entity.Property(e => e.VolumeTo).HasColumnType("decimal(18, 5)");
        });

        modelBuilder.Entity<WalletHistory>(entity =>
        {
            entity.ToTable("WalletHistory");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Uid).HasColumnName("UId");
            entity.Property(e => e.Wallet).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<WebConfiguration>(entity =>
        {
            entity.ToTable("WebConfiguration");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Currency).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CurrencyPayHelp).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CurrencyReal).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CurrencyShip).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.DevTelegramGroup).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.FeeBuyProMin).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Gganalytics).HasColumnName("GGAnalytics");
            entity.Property(e => e.Ggmap).HasColumnName("GGMap");
            entity.Property(e => e.GgsearchCode).HasColumnName("GGSearchCode");
            entity.Property(e => e.HotLine)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.HotLineFeeback)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.HotLineSupport)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Ogdescription).HasColumnName("OGDescription");
            entity.Property(e => e.Ogimage).HasColumnName("OGImage");
            entity.Property(e => e.Ogtitle).HasColumnName("OGTitle");
            entity.Property(e => e.OgtwitterDescription).HasColumnName("OGTwitterDescription");
            entity.Property(e => e.OgtwitterImage).HasColumnName("OGTwitterImage");
            entity.Property(e => e.OgtwitterTitle).HasColumnName("OGTwitterTitle");
            entity.Property(e => e.OneSignalAppId).HasColumnName("OneSignalAppID");
            entity.Property(e => e.RestApikey).HasColumnName("RestAPIKey");
            entity.Property(e => e.WebsiteName).HasMaxLength(50);
        });

        modelBuilder.Entity<WeightFee>(entity =>
        {
            entity.ToTable("WeightFee");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CnwarehouseId).HasColumnName("CNWarehouseId");
            entity.Property(e => e.CnwarehouseName).HasColumnName("CNWarehouseName");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PriceReal).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.VnwarehouseId).HasColumnName("VNWarehouseId");
            entity.Property(e => e.VnwarehouseName).HasColumnName("VNWarehouseName");
            entity.Property(e => e.WeightFrom).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.WeightTo).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<WithDraw>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_WidthDraw");

            entity.ToTable("WithDraw");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Bank).HasMaxLength(100);
            entity.Property(e => e.BankNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Content).HasMaxLength(1000);
            entity.Property(e => e.CreatedBy).HasMaxLength(30);
            entity.Property(e => e.Uid).HasColumnName("UId");
            entity.Property(e => e.UpdatedBy).HasMaxLength(30);
            entity.Property(e => e.Username).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
