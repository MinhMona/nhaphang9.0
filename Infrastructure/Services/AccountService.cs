using Application.Extensions;
using Application.Utilities;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Requests;
using Domain.Requests.AuthRequests;
using Domain.Searchs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AccountService : DomainService<Account, AccountRequest, AccountSearch>, IAccountService
    {
        protected IConfiguration _configuration;

        public AccountService(IUnitOfWork _unitOfWork, IMapper _mapper, IConfiguration configuration) : base(_unitOfWork, _mapper)
        {
            _configuration = configuration;
        }

        protected override string GetStoreProcName()
        {
            return "GetPagingData_Account";
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            var account = await Queryable.FirstOrDefaultAsync(x => x.Username == username && !x.Deleted);
            if (account == null)
                throw new UnauthorizedAccessException("Wrong username");
            if (!account.Active)
                throw new UnauthorizedAccessException("Account was blocked");
            if (!SecurityUtilities.HashSHA1(password).Equals(account.Password))
                throw new UnauthorizedAccessException("Wrong password");
            var token = this.GenerateToken(account);
            return token;
        }

        public async Task<string> RegistrationAsync(RegistrationRequest request)
        {
            var account = new Account()
            {
                Username = request.Username,
                RoleId = Guid.Parse(RoleConstant.EndUser),
                Email = request.Email,
                Phone = request.Phone,
                Fullname = request.Fullname
            };
            account.Password = SecurityUtilities.HashSHA1(request.Password);
            await _unitOfWork.Repository<Account>().CreateAsync(account);
            await _unitOfWork.Complete();
            _unitOfWork.Repository<Account>().Detach(account);
            var token = this.GenerateToken(account);
            return token;
        }

        public async Task<bool> HasPermission(Guid roleId, string[] roleNames)
        {
            var role = await _unitOfWork.Repository<Role>().GetQueryable().FirstOrDefaultAsync(x => x.Id == roleId);
            if (role == null)
                return false;
            if (roleNames.Contains(role.Name))
                return true;
            return false;
        }

        protected string GenerateToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var appSettingsSection = _configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var loginModel = new LoginModel()
            {
                UserId = account.Id,
                Username = account.Username,
                RoleId = account.RoleId,
                IsAdmin = account.IsAdmin,
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                            {
                                new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(loginModel))
                            }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<bool> InsertUser(AccountRequest request)
        {
            return await Task.Run(() =>
            {
                double currentDate = Timestamp.Now();
                string currentUser = LoginContext.Instance.CurrentUser.Username;
                string password = SecurityUtilities.HashSHA1(request.Password);
                string query = $"INSERT INTO [dbo].[Accounts] ([Id],[Username],[Password], [RoleId] ,[Created] ,[CreatedBy] ,[Updated] ,[UpdatedBy] ,[Deleted] ,[Active] ,[IsAdmin]) " +
                $"VALUES ('{Guid.NewGuid()}','{request.Username}','{password}','{RoleConstant.EndUser}', {currentDate}, '{currentUser}',{currentDate},'{currentUser}',0,1,0)";
                return _unitOfWork.Repository<Account>().ExecuteNonQuery(query) > 0;
            });

        }
    }
}
