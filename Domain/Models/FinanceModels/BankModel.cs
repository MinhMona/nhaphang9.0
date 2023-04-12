using Domain.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.FinanceModels
{
    public class BankModel : BaseModel
    {
        public string? BankName { get; set; }

        public string? BankNumber { get; set; }

        public string? BankHolder { get; set; }

        public string? Branch { get; set; }

        public string? Image { get; set; }

        public string? Qrimage { get; set; }
    }
}
