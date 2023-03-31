using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Domain.Requests;
using Domain.Searchs.DomainSearchs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class WebConfigurationService : DomainService<WebConfiguration, WebConfigurationRequest, BaseSearch>, IWebConfigurationService
    {
        protected IConfiguration _configuration;
        protected IAppDbContext _appDbContext;

        public WebConfigurationService(IUnitOfWork _unitOfWork, IMapper _mapper, IAppDbContext appDbContext, IConfiguration configuration) : base(_unitOfWork, _mapper)
        {
            _configuration = configuration;
            _appDbContext = appDbContext;
        }

        public async Task<WebConfigurationModel> GetWebConfiguration()
        {
            var webConfig = await _unitOfWork.Repository<WebConfiguration>().GetQueryable().FirstOrDefaultAsync();
            return _mapper.Map<WebConfigurationModel>(webConfig);
        }
    }
}
