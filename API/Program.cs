using Application.Extensions;
using AutoMapper;
using BaseAPI.AutoMappers;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AppAutoMapper());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddHttpClient();

builder.Services.ConfigureService();
builder.Services.AddScoped(typeof(IDomainRepository<>), typeof(DomainRepository<>));
builder.Services.AddScoped(typeof(IQueryRepository), typeof(QueryRepository));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAppDbContext, AppDbContext>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddTransient<ITokenManagerService, TokenManagerService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
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
                //Scheme = "oauth2",
                //Name = "Bearer",
                //In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
var appSettings = appSettingsSection.Get<AppSettings>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
string secret = appSettings != null ? appSettings.Secret : string.Empty;
var key = Encoding.ASCII.GetBytes(secret);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
                    Path.Combine(app.Environment.ContentRootPath, "Uploads")),
    RequestPath = string.Empty
});

app.UseStaticHttpContext();

app.UseSession();

app.UseHttpsRedirection();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<JwtMiddleware>();

app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BaseSource");
    c.RoutePrefix = "docs";
});

app.MapControllers();

app.Run();
