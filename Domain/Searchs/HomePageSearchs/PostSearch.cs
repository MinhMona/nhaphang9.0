using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Searchs.HomePageSearchs
{
    public class PostSearch : HomeSearch
    {
        public Guid? CategoryId { get; set; }
    }
}
