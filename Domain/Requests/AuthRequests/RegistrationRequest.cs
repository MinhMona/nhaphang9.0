using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Requests.AuthRequests
{
    public class RegistrationRequest : LoginRequest
    {
        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string Fullname { get; set; } = string.Empty;
    }
}
