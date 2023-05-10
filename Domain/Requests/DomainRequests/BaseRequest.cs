using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Requests.DomainRequests
{
    public class BaseRequest
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Cờ check xóa
        /// </summary>
        public bool? Deleted { get; set; } = false;

        /// <summary>
        /// Cờ active
        /// </summary>
        public bool? Active { get; set; } = true;
    }
}
