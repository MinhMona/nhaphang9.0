using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Requests.HomePageRequests
{
    public class CustomerBenefitRequest : HomeRequest
    {
        public int? Type { get; set; }
    }
}
