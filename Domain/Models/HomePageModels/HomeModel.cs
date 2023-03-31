using Domain.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.HomePageModels
{
    public class HomeModel : BaseModel
    {
        public string? Name { get; set; }

        public string? Code { get; set; }

        public string? Description { get; set; }

        public int? Position { get; set; }

        public string? Image { get; set; }

        public string? Link { get; set; }
    }
}
