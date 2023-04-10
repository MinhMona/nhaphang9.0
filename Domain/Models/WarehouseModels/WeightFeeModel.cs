using Domain.Models.DomainModels;

namespace Domain.Models.WarehouseModels
{
    public class WeightFeeModel : BaseModel
    {
        public Guid? CnwarehouseId { get; set; }

        public string? CnwarehouseName { get; set; }

        public Guid? VnwarehouseId { get; set; }

        public string? VnwarehouseName { get; set; }

        public Guid? ShippingTypeId { get; set; }

        public string? ShippingTypeName { get; set; }

        public bool? Type { get; set; }

        public string? TypeName { get; set; }

        public decimal? WeightFrom { get; set; }

        public decimal? WeightTo { get; set; }

        public decimal? Price { get; set; }

        public decimal? PriceReal { get; set; }
    }
}
