using Application.Extensions;
using Application.Services;
using Application.Services.BackgroundServices;
using Application.Services.HomePageServices;
using AutoMapper;
using BaseAPI;
using BaseAPI.AutoMappers;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var SignalROrigins = "SignalROrigins";

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.ConfigureRepositoryWrapper();
builder.Services.ConfigureService();
builder.Services.ConfigureSwagger();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
    options.AddPolicy(MyAllowSpecificOrigins,
    builder =>
    {
        builder
        .WithOrigins("https://localhost:5001")
        .AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader()
       ;
    });
    options.AddPolicy(SignalROrigins,
    builder =>
    {
        builder
       .AllowAnyMethod()
       .AllowAnyHeader()
       .AllowCredentials()
       .SetIsOriginAllowed(hostName => true);
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddMemoryCache(); 

var appSettingsSection = builder.Configuration.GetSection("AppSettings");
var appSettings = appSettingsSection.Get<AppSettings>();
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

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSignalR();

builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
{
    loggerConfiguration
        .Enrich.FromLogContext()
    .WriteTo.Console();
});

builder.Services.AddHostedService<HomePageService>();
builder.Services.AddHostedService<NotificationService>();
builder.Services.AddSingleton<IBackgroundNotiQueue, BackgroundNotiQueue>();

var app = builder.Build();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
                    Path.Combine(app.Environment.ContentRootPath, "Uploads")),
    RequestPath = string.Empty
});

app.UseStaticHttpContext();

app.UseSession();
app.UseCookiePolicy();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();
app.UseAuthentication();
//app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<JwtMiddleware>();
app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("../swagger/v1/swagger.json", "BaseSource");
    c.InjectStylesheet("../css/swagger.min.css");
    c.RoutePrefix = "docs";
});

app.MapControllers();
app.MapHub<DomainHub>("/hub").RequireCors(SignalROrigins);
app.Run();
