using Domain.Requests.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Requests.CartRequests
{
    public class OrderShopTempRequest : BaseRequest
    {
        public string? ShopId { get; set; }

        public string? ShopName { get; set; }

        public double? Currency { get; set; }

        public string? Link { get; set; }

        public int? MinimumQuantity { get; set; }

        public string? SellerId { get; set; }

        public string? ItemId { get; set; }

        public string? Site { get; set; }

        public string? Title { get; set; }

        public string? WangWang { get; set; }

        public string? PriceStep { get; set; }

        public string? Tool { get; set; }

        public string? VersionTool { get; set; }

        public List<OrderTempRequest>? Orders { get; set; }
    }
}
