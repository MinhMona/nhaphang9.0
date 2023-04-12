using Domain.Models.DomainModels;

namespace Domain.Models
{
    public class ShippingTypeModel : BaseModel
    {
        public string? Code { get; set; }

        public string? Name { get; set; }
    }
}
