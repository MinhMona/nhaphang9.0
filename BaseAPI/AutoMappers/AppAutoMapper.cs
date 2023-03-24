using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Models;
using Domain.Requests;

namespace BaseAPI.AutoMappers
{
    public class AppAutoMapper : Profile
    {
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
