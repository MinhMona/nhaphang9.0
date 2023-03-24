using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public class AccountLogin
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string Username { get; set; } = string.Empty;
    }
}
