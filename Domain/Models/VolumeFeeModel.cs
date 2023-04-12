using Domain.Models.DomainModels;

namespace Domain.Models
{
    public class VolumeFeeModel : BaseModel
    {
        public Guid? CnwarehouseId { get; set; }

        public string? CnwarehouseName { get; set; }

        public Guid? VnwarehouseId { get; set; }

        public string? VnwarehouseName { get; set; } 

        public Guid? ShippingTypeId { get; set; }

        public string? ShippingTypeName { get; set; }

        public bool? Type { get; set; }

        public string? TypeName { get; set; }

        public decimal? VolumeFrom { get; set; }

        public decimal? VolumeTo { get; set; }

        public decimal? Price { get; set; }
    }
}
