using Domain.Requests.DomainRequests;

namespace Domain.Requests.FeeConfigRequests
{
    public class FeeCheckProductRequest : BaseRequest
    {
        public string? Name { get; set; }

        public int? Type { get; set; }

        public decimal? QuantityFrom { get; set; }

        public decimal? QuantityTo { get; set; }

        public decimal? Price { get; set; }
    }
}
