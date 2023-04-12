using Domain.Requests.DomainRequests;

namespace Domain.Requests.WarehouseRequests
{
    public class ShippingTypeRequest : BaseRequest
    {
        public string? Code { get; set; }

        public string? Name { get; set; }
    }
}
