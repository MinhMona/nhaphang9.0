using Application.Services;
using Application.Services.HomePageServices;
using Application.Services.WarehouseServicces;
using Domain.Interfaces;
using Domain.Interfaces.HomeInterfaces;
using Infrastructure.DbContexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.OpenApi.Models;

namespace BaseAPI
{
    /// <summary>
    /// Configuration of extension services
    /// </summary>
    public static class ConfigureExtension
    {
        /// <summary>
        /// ConfigureService
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureService(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IWebConfigurationService, WebConfigurationService>();

            #region HomePage
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IStepService, StepService>();
            services.AddScoped<ICustomerTalkService, CustomerTalkService>();
            services.AddScoped<ICustomerBenefitService, CustomerBenefitService>();
            services.AddScoped<IPostCategoryService, PostCategoryService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IMenuService, MenuService>();
            #endregion

            #region Warehouse
            services.AddScoped<ICNWarehouseService, CNWarehouseService>();
            services.AddScoped<IVNWarehouseService, VNWarehouseService>();
            services.AddScoped<IShippingTypeService, ShippingTypeService>();
            services.AddScoped<IWeightFeeService, WeightFeeService>();
            services.AddScoped<IVolumeFeeService, VolumeFeeService>();
            #endregion
            services.AddTransient<ITokenManagerService, TokenManagerService>();
            services.AddScoped<ISearchService, SearchService>();
            

        }

        /// <summary>
        /// ConfigureSwagger
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BaseSource", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Jwt auth header",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                        },
                        new List<string>()
                    }
                });
            });
        }

        /// <summary>
        /// Configure Repository
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddScoped(typeof(IDomainRepository<>), typeof(DomainRepository<>));
            services.AddScoped<IQueryRepository, QueryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
