using Domain.Models.DomainModels;

namespace Domain.Models.WarehouseModels
{
    public class VNWarehouseModel : BaseModel
    {
        public string? Code { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }
    }
}
