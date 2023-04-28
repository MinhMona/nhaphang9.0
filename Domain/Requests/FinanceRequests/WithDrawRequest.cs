using Domain.Requests.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Requests.FinanceRequests
{
    public class WithDrawRequest : BaseRequest
    {
        public Guid? Uid { get; set; }

        public decimal? Amount { get; set; }

        public string? BankNumber { get; set; }

        public string? Bank { get; set; }

        public int? Status { get; set; }

        public string? Username { get; set; }

        public string? Content { get; set; }
    }
}
