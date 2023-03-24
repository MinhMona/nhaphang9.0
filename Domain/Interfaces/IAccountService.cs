using Domain.Entities;
using Domain.Requests;
using Domain.Requests.AuthRequests;
using Domain.Searchs;

namespace Domain.Interfaces
{
    public interface IAccountService : IDomainService<Account, AccountRequest, AccountSearch>
    {
        Task<string> LoginAsync(string username, string password);
        Task<string> RegistrationAsync(RegistrationRequest request);
        Task<bool> HasPermission(Guid roleId, string[] roleNames);

        Task<bool> InsertUser(AccountRequest request);
    }
}
