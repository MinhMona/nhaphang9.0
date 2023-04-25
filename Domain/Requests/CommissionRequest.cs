using Domain.Requests.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Requests
{
    public class CommissionRequest : BaseRequest
    {
        public int? Status { get; set; }
    }
}
