using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class Permission
    {
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public bool IsPermission { get; set; }
    }
}
