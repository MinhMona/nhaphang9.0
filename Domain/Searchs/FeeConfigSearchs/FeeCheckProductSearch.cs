﻿using Domain.Searchs.DomainSearchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Searchs.FeeConfigSearchs
{
    public class FeeCheckProductSearch : BaseSearch
    {
        public int? Type { get; set; }

        public int? Value { get; set; }

    }
}
