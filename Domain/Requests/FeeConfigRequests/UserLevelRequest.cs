using Domain.Requests.DomainRequests;

namespace Domain.Requests.FeeConfigRequests
{
    public class UserLevelRequest : BaseRequest
    {
        public string? Name { get; set; }

        public decimal? FeeBuyProDis { get; set; }

        public decimal? FeeShippingDis { get; set; }

        public decimal? MinAccumulate { get; set; }

        public decimal? MaxAccumulate { get; set; }

        public decimal? MinDeposit { get; set; }
    }
}
