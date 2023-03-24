using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; } = string.Empty;
        public bool GrantPermissionDebug { get; set; }
    }
}
