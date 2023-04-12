﻿using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Entities.DomainEntities;
using Domain.Models;
using Domain.Models.DomainModels;
using Domain.Models.HomePageModels;
using Domain.Requests;
using Domain.Requests.DomainRequests;
using Domain.Requests.HomePageRequests;
using Domain.Requests.WarehouseRequests;

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

            #region PostCategory
            CreateMap<PostCategoryModel, PostCategory>().ReverseMap();
            CreateMap<PostCategoryRequest, PostCategory>().ReverseMap();
            CreateMap<PagedList<PostCategoryModel>, PagedList<PostCategory>>().ReverseMap();
            #endregion

            #region Post
            CreateMap<PostModel, Post>().ReverseMap();
            CreateMap<PostRequest, Post>().ReverseMap();
            CreateMap<PagedList<PostModel>, PagedList<Post>>().ReverseMap();
            #endregion

            #region Menu
            CreateMap<HomeModel, Menu>().ReverseMap();
            CreateMap<HomeRequest, Menu>().ReverseMap();
            CreateMap<PagedList<HomeModel>, PagedList<Menu>>().ReverseMap();
            #endregion

            #endregion

            #region Warehouse

            #region CNWarehouse
            CreateMap<CNWarehouseModel, Cnwarehouse>().ReverseMap();
            CreateMap<CNWarehouseRequest, Cnwarehouse>().ReverseMap();
            CreateMap<PagedList<CNWarehouseModel>, PagedList<Cnwarehouse>>().ReverseMap();
            #endregion

            #region VNWarehouse
            CreateMap<VNWarehouseModel, Vnwarehouse>().ReverseMap();
            CreateMap<VNWarehouseRequest, Vnwarehouse>().ReverseMap();
            CreateMap<PagedList<VNWarehouseModel>, PagedList<Vnwarehouse>>().ReverseMap();

            #endregion

            #region ShippingType
            CreateMap<ShippingTypeModel, ShippingType>().ReverseMap();
            CreateMap<ShippingTypeRequest, ShippingType>().ReverseMap();
            CreateMap<PagedList<ShippingTypeModel>, PagedList<ShippingType>>().ReverseMap();
            #endregion

            #region WeightFee
            CreateMap<WeightFeeModel, WeightFee>().ReverseMap();
            CreateMap<WeightFeeRequest, WeightFee>().ReverseMap();
            CreateMap<PagedList<WeightFeeModel>, PagedList<WeightFee>>().ReverseMap();
            #endregion

            #region VolumeFee
            CreateMap<VolumeFeeModel, VolumeFeeModel>().ReverseMap();
            CreateMap<VolumeFeeRequest, VolumeFee>().ReverseMap();
            CreateMap<PagedList<VolumeFeeModel>, PagedList<VolumeFeeModel>>().ReverseMap();
            #endregion

            #endregion
        }
    }

}
