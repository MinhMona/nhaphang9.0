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
    public class WithDrawService : DomainService<WithDraw, WithDrawRequest, RechargeSearch>, IWithDrawService
    {
        protected readonly IAppDbContext _context;
        public WithDrawService(IUnitOfWork unitOfWork, IMapper mapper, IAppDbContext context) : base(unitOfWork, mapper)
        {
            _context = context;
        }

        protected override string GetStoreProcName()
        {
            return "WithDrawPaging";
        }

        public override async Task<bool> CreateAsync(WithDrawRequest request)
        {
            //Using transaction
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var user = await _unitOfWork.Repository<Account>().GetQueryable().FirstOrDefaultAsync(x => x.Id == request.Uid);
                    if (user == null)
                        throw new KeyNotFoundException("Account not found");
                    decimal userWallet = (user.Wallet ?? 0) - (request.Amount ?? 0);
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
                        Type = (int)WalletHistoryType.AdminWithDraw,
                        Price = request.Amount,
                        Wallet = userWallet,
                        Content = request.Content,
                    };
                    await _unitOfWork.Repository<WalletHistory>().CreateAsync(walletHistory);

                    await _unitOfWork.Repository<WithDraw>().CreateAsync(_mapper.Map<WithDraw>(request));
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

        public override async Task<bool> UpdateAsync(WithDrawRequest request)
        {
            Guid loginedId = LoginContext.Instance.CurrentUser.UserId;
            //Using transaction
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (request.Status == (int)WithDrawStatus.Canceled)
                    {
                        if (!loginedId.Equals(request.Uid))
                        {
                            //Send noti for user that admin cancel user rechager with Id
                        }
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
                            Type = (int)WalletHistoryType.WithDraw,
                            Price = request.Amount,
                            Wallet = userWallet,
                            Content = "Hủy lệnh rút tiền",
                        };
                        await _unitOfWork.Repository<WalletHistory>().CreateAsync(walletHistory);
                    }
                    await _unitOfWork.Repository<WithDraw>().UpdateFieldsSaveAsync(_mapper.Map<WithDraw>(request), new Expression<Func<WithDraw, object>>[]
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
            string data = await this.GetJson("WithDrawPaging", search);
            return data;
        }
    }
}
