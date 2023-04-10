using Domain.Requests.DomainRequests;

namespace Domain.Requests.WarehouseRequests
{
    public class VNWarehouseRequest : BaseRequest
    {
        public string? Code { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }
    }
}
