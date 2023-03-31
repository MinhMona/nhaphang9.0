using Domain.Requests.DomainRequests;

namespace Domain.Requests
{
    public class AccountRequest : BaseRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public Guid? RoleId { get; set; }
        public int? RoleNumberId { get; set; }
    }
}
