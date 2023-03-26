using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Models;
using Domain.Requests;

namespace BaseAPI.AutoMappers
{
    /// <summary>
    /// Auto Mapper Profile
    /// </summary>
    public class AppAutoMapper : Profile
    {
        /// <summary>
        /// Define Mapper
        /// </summary>
        public AppAutoMapper()
        {
            #region Account
            CreateMap<AccountModel, Account>().ReverseMap();
            CreateMap<AccountRequest, Account>().ReverseMap();
            CreateMap<PagedList<AccountModel>, PagedList<Account>>().ReverseMap();
            #endregion

            #region Role
            CreateMap<RoleModel, Role>().ReverseMap();
            #endregion
        }
    }
}
