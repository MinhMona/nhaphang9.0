using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public class LoginModel
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
    }
}
