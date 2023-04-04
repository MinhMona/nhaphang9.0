using Application.Utilities;
using Domain.Interfaces;
using Domain.Searchs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    /// <summary>
    /// Search product
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="searchService"></param>
        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public AppDomainResult SearchContent(SearchRequest searchRequest)
        {
            return new AppDomainResult()
            {
                Data = searchService.SearchContent(searchRequest.Site, searchRequest.Content ?? string.Empty),
                ResultCode = (int)HttpStatusCode.OK,
                Success = true,
                ResultMessage = "Translate success"
            };
        }
    }
}
