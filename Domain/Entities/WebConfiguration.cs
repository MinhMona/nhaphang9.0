using Domain.Entities.DomainEntities;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class WebConfiguration : BaseEntity
{
    public decimal? Currency { get; set; }

    public decimal? CurrencyShip { get; set; }

    public decimal? CurrencyPayHelp { get; set; }

    public double? SaleBeforePercent { get; set; }

    public double? SaleAfterPercent { get; set; }

    public double? OrderingPercent { get; set; }

    public double? PayHelpPercent { get; set; }

    public double? InsurancePercent { get; set; }

    public int? TotalLink { get; set; }

    public int? RemoveCartDay { get; set; }

    public string? WebsiteName { get; set; }

    public string? Logo { get; set; }

    public string? Banner { get; set; }

    public string? BannerText { get; set; }

    public string? ChromeExtension { get; set; }

    public string? CocCocExtension { get; set; }

    public string? ShortName { get; set; }

    public string? LongName { get; set; }

    public string? SummaryName { get; set; }

    public string? TaxCode { get; set; }

    public string? TimeWorking { get; set; }

    public string? EmailContact { get; set; }

    public string? EmailSupport { get; set; }

    public string? HotLine { get; set; }

    public string? HotLineSupport { get; set; }

    public string? HotLineFeeback { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? Address3 { get; set; }

    public string? Facebook { get; set; }

    public string? FacebookFanpage { get; set; }

    public string? Twitter { get; set; }

    public string? Instagram { get; set; }

    public string? Youtue { get; set; }

    public string? Ggmap { get; set; }

    public string? Zalo { get; set; }

    public string? Wechat { get; set; }

    public string? Skype { get; set; }

    public string? Printerest { get; set; }

    public string? NotiRun { get; set; }

    public string? PopupTitle { get; set; }

    public string? PopupEmail { get; set; }

    public string? PopupDescription { get; set; }

    public string? Title { get; set; }

    public string? Ogtitle { get; set; }

    public string? Ogdescription { get; set; }

    public string? Ogimage { get; set; }

    public string? OgtwitterTitle { get; set; }

    public string? OgtwitterDescription { get; set; }

    public string? OgtwitterImage { get; set; }

    public string? Local { get; set; }

    public string? MetaKeyword { get; set; }

    public string? MetaDescription { get; set; }

    public string? Gganalytics { get; set; }

    public string? GgsearchCode { get; set; }

    public string? OneSignalAppId { get; set; }

    public string? RestApikey { get; set; }

    public decimal? FeeBuyProMin { get; set; }

    public decimal? CurrencyReal { get; set; }
}

