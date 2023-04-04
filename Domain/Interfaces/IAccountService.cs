using Domain.Entities;
using Domain.Models;
using Domain.Requests;
using Domain.Requests.AuthRequests;
using Domain.Searchs;

namespace Domain.Interfaces
{
    public interface IAccountService : IDomainService<Account, AccountRequest, AccountSearch>
    {
        Task<AuthenticationModel> LoginAsync(string username, string password);
        Task<AuthenticationModel> RegistrationAsync(RegistrationRequest request);
        Task<string> RefreshAsync(string refreshToken);
        Task<bool> HasPermission(Guid roleId, string[] roleNames);

        Task<bool> InsertUser(AccountRequest request);
    }
}
