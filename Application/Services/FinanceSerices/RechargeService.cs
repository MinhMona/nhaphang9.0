using Application.Extensions;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.FinanceInterfaces;
using Domain.Requests.FinanceRequests;
using Domain.Searchs;
using Domain.Searchs.FinanceSearchs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Application.Utilities.EnumConstant;

namespace Application.Services.FinanceSerices
{
    public class RechargeService : DomainService<Recharge, RechargeRequest, RechargeSearch>, IRechargeService
    {
        protected readonly IAppDbContext _context;
        public RechargeService(IUnitOfWork unitOfWork, IMapper mapper, IAppDbContext context) : base(unitOfWork, mapper)
        {
            _context = context;
        }

        protected override string GetStoreProcName()
        {
            return "RechargePaging";
        }

        public override async Task<bool> CreateAsync(RechargeRequest request)
        {
            //Using transaction
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    //Approved
                    if (request.Status == (int)RechargeStatus.Approved)
                    {
                        var user = await _unitOfWork.Repository<Account>().GetQueryable().FirstOrDefaultAsync(x => x.Id == request.Uid);
                        if (user == null)
                            throw new KeyNotFoundException("Account not found");
                        decimal userWallet = (user.Wallet ?? 0) + (request.Amount ?? 0);
                        user.Wallet = userWallet;
                        await _unitOfWork.Repository<Account>().UpdateFieldsSaveAsync(user, new Expression<Func<Account, object>>[]
                        {
                            x => x.Wallet,
                            x => x.Updated,
                            x => x.UpdatedBy
                        });

                        WalletHistory walletHistory = new WalletHistory()
                        {
                            Uid = request.Uid,
                            Type = (int)WalletHistoryType.AdminRecharge,
                            Price = request.Amount,
                            Wallet = userWallet,
                            Content = request.Content,
                        };
                        await _unitOfWork.Repository<WalletHistory>().CreateAsync(walletHistory);
                    }
                    await _unitOfWork.Repository<Recharge>().CreateAsync(_mapper.Map<Recharge>(request));
                    await _unitOfWork.Complete();
                    await dbContextTransaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    await dbContextTransaction.RollbackAsync();
                    throw new AppException(ex.Message);
                }
            }
        }

        public override async Task<bool> UpdateAsync(RechargeRequest request)
        {
            Guid loginedId = LoginContext.Instance.CurrentUser.UserId;
            //Using transaction
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    switch (request.Status)
                    {
                        case (int)RechargeStatus.Canceled:
                            if (!loginedId.Equals(request.Uid))
                            {
                                //Send noti for user that admin cancel user rechager with Id
                            }
                            break;
                        case (int)RechargeStatus.Approved:
                            var user = await _unitOfWork.Repository<Account>().GetQueryable().FirstOrDefaultAsync(x => x.Id == request.Uid);
                            if (user == null)
                                throw new KeyNotFoundException("Account not found");
                            decimal userWallet = (user.Wallet ?? 0) + (request.Amount ?? 0);
                            user.Wallet = userWallet;
                            await _unitOfWork.Repository<Account>().UpdateFieldsSaveAsync(user, new Expression<Func<Account, object>>[]
                            {
                                x => x.Wallet,
                                x => x.Updated,
                                x => x.UpdatedBy
                            });
                            WalletHistory walletHistory = new WalletHistory()
                            {
                                Uid = request.Uid,
                                Type = (int)WalletHistoryType.Recharge,
                                Price = request.Amount,
                                Wallet = userWallet,
                                Content = request.Content,
                            };
                            await _unitOfWork.Repository<WalletHistory>().CreateAsync(walletHistory);
                            break;
                        default:
                            break;
                    }
                    await _unitOfWork.Repository<Recharge>().UpdateFieldsSaveAsync(_mapper.Map<Recharge>(request), new Expression<Func<Recharge, object>>[]
                    {
                        x => x.Status,
                        x => x.Updated,
                        x => x.UpdatedBy
                    });
                    await _unitOfWork.Complete();
                    await dbContextTransaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    await dbContextTransaction.RollbackAsync();
                    throw new AppException(ex.Message);
                }
            }
        }

        public async Task<string> GetDataJson(RechargeSearch search)
        {
            string data = await this.GetJson("RechargePaging", search);
            return data;
        }
    }
}
