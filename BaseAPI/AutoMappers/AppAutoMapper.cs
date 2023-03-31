using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Entities.DomainEntities;
using Domain.Models;
using Domain.Models.DomainModels;
using Domain.Models.HomePageModels;
using Domain.Requests;
using Domain.Requests.DomainRequests;
using Domain.Requests.HomePageRequests;

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

            #region WebConfiguration
            CreateMap<WebConfigurationModel, WebConfiguration>().ReverseMap();
            CreateMap<WebConfigurationRequest, WebConfiguration>().ReverseMap();
            #endregion

            #region Account
            CreateMap<AccountModel, Account>().ReverseMap();
            CreateMap<AccountRequest, Account>().ReverseMap();
            CreateMap<PagedList<AccountModel>, PagedList<Account>>().ReverseMap();
            #endregion

            #region Role
            CreateMap<RoleModel, Role>().ReverseMap();
            #endregion

            #region HomePage

            #region Service
            CreateMap<HomeModel, Service>().ReverseMap();
            CreateMap<HomeRequest, Service>().ReverseMap();
            CreateMap<PagedList<HomeModel>, PagedList<Service>>().ReverseMap();
            #endregion

            #region Step
            CreateMap<HomeModel, Step>().ReverseMap();
            CreateMap<HomeRequest, Step>().ReverseMap();
            CreateMap<PagedList<HomeModel>, PagedList<Step>>().ReverseMap();
            #endregion

            #region CustomerTalk
            CreateMap<HomeModel, CustomerTalk>().ReverseMap();
            CreateMap<HomeRequest, CustomerTalk>().ReverseMap();
            CreateMap<PagedList<HomeModel>, PagedList<CustomerTalk>>().ReverseMap();
            #endregion

            #region CustomerBenefit
            CreateMap<CustomerBenefitModel, CustomerBenefit>().ReverseMap();
            CreateMap<CustomerBenefitRequest, CustomerBenefit>().ReverseMap();
            CreateMap<PagedList<CustomerBenefitModel>, PagedList<CustomerBenefit>>().ReverseMap();
            #endregion
            #endregion
        }
    }
    /// <summary>
    /// Auto Mapper Profile
    /// </summary>
    //public class AppAutoMapper<E, M, R> : Profile where E : BaseEntity where M : BaseModel where R : BaseRequest, new()
    //{
    //    /// <summary>
    //    /// Define Mapper
    //    /// </summary>
    //    public AppAutoMapper()
    //    {

    //        CreateMap<M, E>().ReverseMap();
    //        CreateMap<R, E>().ReverseMap();
    //        CreateMap<PagedList<M>, PagedList<E>>().ReverseMap();
    //    }
    //}
}
