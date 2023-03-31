using Domain.Entities;
using Domain.Models;
using Domain.Requests;
using Domain.Requests.AuthRequests;
using Domain.Searchs;
using Domain.Searchs.DomainSearchs;

namespace Domain.Interfaces
{
    public interface IWebConfigurationService : IDomainService<WebConfiguration, WebConfigurationRequest, BaseSearch>
    {
        Task<WebConfigurationModel> GetWebConfiguration();
    }
}
