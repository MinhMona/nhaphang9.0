using Domain.Requests.DomainRequests;

namespace Domain.Requests.FeeConfigRequests
{
    public class FeeBuyProductRequest : BaseRequest
    {
        public decimal? PriceFrom { get; set; }

        public decimal? PriceTo { get; set; }

        public decimal? Percent { get; set; }
    }
}
