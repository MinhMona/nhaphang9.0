using Domain.Entities;
using Domain.Requests.HomePageRequests;
using Domain.Searchs.HomePageSearchs;

namespace Domain.Interfaces.HomeInterfaces
{
    public interface IPostCategoryService : IDomainService<PostCategory, PostCategoryRequest, HomeSearch>
    {
    }
}
