using Domain.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.CartModels
{
    public class OrderTempModel : BaseModel
    {
        public Guid? OrderShopTempId { get; set; }

        public string? Image { get; set; }

        public double? PriceOrigin { get; set; }

        public double? PricePromotion { get; set; }

        public string? Properties { get; set; }

        public int? Quantity { get; set; }

        public string? SkuId { get; set; }
    }
}
