using Domain.Searchs.DomainSearchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Searchs
{
    public class CommissionSearch: BaseSearch
    {
        public string? Username { get; set; }
        public int? Status { get; set; }
        public float? FromDate { get; set; }
        public float? ToDate { get; set; }
        public int? RoleNumberId { get; set; }
    }
}
