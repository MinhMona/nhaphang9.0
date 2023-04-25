using Domain.Requests.DomainRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Requests.FinanceRequests
{
    public class RechargeRequest : BaseRequest
    {
        public Guid? Uid { get; set; }

        public Guid? BankId { get; set; }

        public decimal? Price { get; set; }

        public string? Content { get; set; }

        /// <summary>
        /// 0: Chưa duyệt; 1: Đã duyệt; 2: Hủy 
        /// </summary>
        public int? Status { get; set; }

        public string? Username { get; set; }
    }
}
