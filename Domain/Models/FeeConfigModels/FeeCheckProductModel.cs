using Domain.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.FeeConfigModels
{
    public class FeeCheckProductModel : BaseModel
    {
        public string? Name { get; set; }

        public int? Type { get; set; }

        public decimal? QuantityFrom { get; set; }

        public decimal? QuantityTo { get; set; }

        public decimal? Price { get; set; }
    }
}
