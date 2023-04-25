using Domain.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CommissionModel : BaseModel
    {
        public int? Type { get; set; }

        public Guid? OrderId { get; set; }

        public Guid? StaffId { get; set; }

        public string? StaffName { get; set; }

        public decimal? Percent { get; set; }

        public decimal? ReceivedPrice { get; set; }

        public double? OrderCompleteDate { get; set; }

        public int? Status { get; set; }

        public string? RoleName { get; set; }
        public int? RoleNumberId { get; set; }

    }
}
