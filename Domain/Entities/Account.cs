using Domain.Entities.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;
        public Guid RoleId { get; set; }

        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Fullname { get; set; }
    }
}
