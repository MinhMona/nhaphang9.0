using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Requests.AuthRequests
{
    public class LoginRequest
    {
        public string Username { set; get; } = string.Empty;

        public string Password { set; get; } = string.Empty;
    }
}
