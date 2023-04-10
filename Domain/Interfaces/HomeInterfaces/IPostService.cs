using Domain.Common;
using Domain.Entities;
using Domain.Models.HomePageModels;
using Domain.Requests.HomePageRequests;
using Domain.Searchs.HomePageSearchs;

namespace Domain.Interfaces.HomeInterfaces
{
    public interface IPostService : IDomainService<Post, PostRequest, PostSearch>
    {
        PagedList<PostModel> GetPaging(PostSearch baseSearch);
    }
}
