using Domain.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RoleModel : BaseModel
    {
        /// <summary>
        /// Role name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Permission of role
        /// </summary>
        public string Permission { get; set; } = string.Empty;
    }
}
