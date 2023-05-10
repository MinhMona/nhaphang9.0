using Domain.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.FinanceModels
{
    public class RechargeModel : BaseModel
    {
        public Guid? Uid { get; set; }

        public Guid? BankId { get; set; }

        public decimal? Amount { get; set; }

        public string? Content { get; set; }

        public string? Username { get; set; }

        public int? Status { get; set; }
    }
}
