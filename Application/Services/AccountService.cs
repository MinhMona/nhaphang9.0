using Application.Extensions;
using Application.Utilities;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Domain.Requests;
using Domain.Requests.AuthRequests;
using Domain.Searchs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services
{
    public class AccountService : DomainService<Account, AccountRequest, AccountSearch>, IAccountService
    {
        protected IConfiguration _configuration;
        protected IAppDbContext _appDbContext;

        public AccountService(IUnitOfWork _unitOfWork, IMapper _mapper, IAppDbContext appDbContext, IConfiguration configuration) : base(_unitOfWork, _mapper)
        {
            _configuration = configuration;
            _appDbContext = appDbContext;
        }

        protected override string GetStoreProcName()
        {
            return "AccountPaging";
        }

        public override Task<bool> CreateAsync(AccountRequest request)
        {
            request.Password = SecurityUtilities.HashSHA1(request.Password);
            return base.CreateAsync(request);
        }
        public override Task<bool> UpdateAsync(AccountRequest request)
        {
            request.Password = SecurityUtilities.HashSHA1(request.Password);
            return base.UpdateAsync(request);
        }

        public async Task<bool> InsertUser(AccountRequest request)
        {
            var account = await Queryable.FirstOrDefaultAsync(x => x.Username == request.Username && !x.Deleted);
            double currentDate = Timestamp.Now();
            string currentUser = null;
            //string currentUser = LoginContext.Instance.CurrentUser.Username;
            string password = SecurityUtilities.HashSHA1(request.Password);
            string query = $"INSERT INTO [dbo].[Account] ([Username],[Password], [RoleId] ,[Created] ,[CreatedBy] ,[Updated] ,[UpdatedBy] ,[Deleted] ,[Active] ,[IsAdmin],[RoleNumberId]) " +
            $"VALUES ('{request.Username}','{password}','{RoleConstant.EndUser}', {currentDate}, '{currentUser}',{currentDate},'{currentUser}',0,1,0,1)";
            return _unitOfWork.QueryRepository().ExecuteNonQuery(query) > 0;
        }

        public async Task<AuthenticationModel> LoginAsync(string username, string password)
        {
            var account = await Queryable.FirstOrDefaultAsync(x => x.Username == username && !x.Deleted);
            if (account == null)
                throw new UnauthorizedAccessException("Wrong username");
            if (!account.Active)
                throw new UnauthorizedAccessException("Account was blocked");
            if (!SecurityUtilities.HashSHA1(password).Equals(account.Password))
                throw new UnauthorizedAccessException("Wrong password");
            return new AuthenticationModel()
            {
                AccessToken = this.GenerateToken(account, false),
                RefreshToken = this.GenerateRefreshToken(account.Id.ToString())
            };
        }

        public async Task<AuthenticationModel> RegistrationAsync(RegistrationRequest request)
        {
            var account = await Queryable.FirstOrDefaultAsync(x => x.Username == request.Username && !x.Deleted);
            if (account == null)
            {
                account = new Account()
                {
                    Username = request.Username,
                    RoleId = Guid.Parse(RoleConstant.EndUser),
                    RoleNumberId = (int)RoleEnum.EndUser,
                    Email = request.Email,
                    Phone = request.Phone
                };
                account.Password = SecurityUtilities.HashSHA1(request.Password);
                await _unitOfWork.Repository<Account>().CreateAsync(account);
                await _unitOfWork.Complete();
                _unitOfWork.Repository<Account>().Detach(account);
                return new AuthenticationModel()
                {
                    AccessToken = this.GenerateToken(account, false),
                    RefreshToken = this.GenerateRefreshToken(account.Id.ToString())
                };
            }
            throw new AppException("Username Already");
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

        protected string GenerateToken(Account account, bool isDev)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var appSettingsSection = _configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var loginModel = new LoginModel()
            {
                UserId = account.Id,
                Username = account.Username,
                RoleId = account.RoleNumberId ?? 0,
                IsAdmin = account.IsAdmin,
                IsDev = isDev
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                            {
                                new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(loginModel))
                            }),
                Expires = DateTime.UtcNow.AddHours(7).AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        protected string DecryptString(string cipherText)
        {
            var appSettingsSection = _configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = appSettings.Refresh;
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        private string GenerateRefreshToken(string accountID)
        {
            var appSettingsSection = _configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = appSettings.Refresh;
            byte[] iv = new byte[16];
            byte[] array;
            accountID += "_" + DateTime.UtcNow.AddHours(7).AddDays(3).ToString();
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(accountID);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(array);
        }

        public async Task<string> RefreshAsync(string refreshToken)
        {
            var accountInfo = DecryptString(refreshToken).Split('_');
            var accountID = new Guid(accountInfo[0]);
            var exp = DateTime.Parse(accountInfo[1]);
            if(exp >= DateTime.UtcNow.AddHours(7))
            {
                var account = await this.GetByIdAsync(accountID);
                if (account == null)
                    throw new UnauthorizedAccessException("Wrong accountID");
                if (!account.Active)
                    throw new UnauthorizedAccessException("Account was blocked");
                return this.GenerateToken(account, false);
            }
            throw new UnauthorizedAccessException("Refresh token time out");
        }
    }
}
