using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Searchs
{
    public class SearchRequest
    {
        public int Site { get; set; }
        public string? Content { get; set; }
    }
}
