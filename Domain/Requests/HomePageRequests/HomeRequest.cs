using Domain.Requests.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Requests.HomePageRequests
{
    public class HomeRequest : BaseRequest
    {
        public string? Name { get; set; }

        public string? Code { get; set; }

        public string? Description { get; set; }

        public int? Position { get; set; }

        public string? Image { get; set; }

        public string? Link { get; set; }
    }
}
