using Domain.Models.DomainModels;

namespace Domain.Models.WarehouseModels
{
    public class ShippingTypeModel : BaseModel
    {
        public string? Code { get; set; }

        public string? Name { get; set; }
    }
}
