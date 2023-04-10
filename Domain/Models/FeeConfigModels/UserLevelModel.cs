using Domain.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.FeeConfigModels
{
    public class UserLevelModel : BaseModel
    {
        public string? Name { get; set; }

        public decimal? FeeBuyProDis { get; set; }

        public decimal? FeeShippingDis { get; set; }

        public decimal? MinAccumulate { get; set; }

        public decimal? MaxAccumulate { get; set; }

        public decimal? MinDeposit { get; set; }
    }
}
