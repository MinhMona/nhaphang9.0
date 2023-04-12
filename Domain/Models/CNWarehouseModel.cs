using Domain.Models.DomainModels;

namespace Domain.Models
{
    public class CNWarehouseModel : BaseModel
    {
        public string? Code { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }
    }
}
