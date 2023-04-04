using Application.Extensions;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Domain.Requests;
using Domain.Searchs.DomainSearchs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Application.Services
{
    public class WebConfigurationService : DomainService<WebConfiguration, WebConfigurationRequest, BaseSearch>, IWebConfigurationService
    {
        protected IAppDbContext _appDbContext;

        public WebConfigurationService(IUnitOfWork _unitOfWork, IMapper _mapper, IAppDbContext appDbContext) : base(_unitOfWork, _mapper)
        {
            _appDbContext = appDbContext;
        }

        public async Task<WebConfigurationModel> GetWebConfiguration()
        {
            var webConfig = await _unitOfWork.Repository<WebConfiguration>().GetQueryable().FirstOrDefaultAsync();
            return _mapper.Map<WebConfigurationModel>(webConfig);
        }

        public async Task<decimal> GetCurreny()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@UID", LoginContext.Instance.CurrentUser != null ? LoginContext.Instance.CurrentUser.UserId : Guid.NewGuid()));
            SqlParameter[] parameters = sqlParameters.ToArray();
            SqlParameter outputParameter = new SqlParameter("Currency", SqlDbType.Decimal);
            outputParameter.Direction = ParameterDirection.Output;
            var currency = await _unitOfWork.QueryRepository().ExcuteStoreGetValue("GetCurrency", parameters, outputParameter);
            return Convert.ToDecimal(currency);
        }

    }
}
