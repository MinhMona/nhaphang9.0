namespace Application.Extensions
{
    public class LoginModel
    {
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDev { get; set; }
    }
}
