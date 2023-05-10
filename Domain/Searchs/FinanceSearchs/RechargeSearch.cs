using Domain.Searchs.DomainSearchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Searchs.FinanceSearchs
{
    public class RechargeSearch : BaseSearch
    {
        public int? Status { get; set; }
        public double? FromDate { get; set; }
        public double? ToDate { get; set; }
    }
}
