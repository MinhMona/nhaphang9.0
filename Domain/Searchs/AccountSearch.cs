using Domain.Searchs.DomainSearchs;

namespace Domain.Searchs
{
    public class AccountSearch : BaseSearch
    {
        public int? TypeAccount { get; set; }
        public int? RoleNumberId { get; set; }
        public Guid? UId { get; set; }
        public Guid? SalerId { get; set; }
        public Guid? OrderingId { get; set; }
        public Guid? RoleId { get; set; }
        public int? TypeSearch{ get; set; }
    }
}
