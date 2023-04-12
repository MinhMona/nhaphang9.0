using Domain.Searchs.DomainSearchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Searchs.WarehouseSearchs
{
    public class WarehouseFeeSearch : BaseSearch
    {
        public Guid? CNWarehouseId { get; set; }
        public Guid? VNWarehouseId { get; set; }
        public Guid? ShippingTypeId { get; set; }
        public bool? Type { get; set; }
        public decimal? Value { get; set; }
    }
}
