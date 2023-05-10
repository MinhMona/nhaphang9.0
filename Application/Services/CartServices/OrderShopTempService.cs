using Application.Extensions;
using Application.Utilities;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.CartInterfaces;
using Domain.Requests.CartRequests;
using Domain.Searchs.DomainSearchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CartServices
{
    public class OrderShopTempService : IOrderShopTempService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderShopTempService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(OrderShopTempRequest request)
        {
            var currentUser = LoginContext.Instance.CurrentUser;
            var currentDate = Timestamp.Now();
            string query = $"DECLARE @InsertedIds TABLE (Id uniqueidentifier) " +
                $"INSERT INTO [dbo].[OrderShopTemp] ([Created] ,[CreatedBy], [Deleted] ,[Active] ,[UId] ," +
                $"[ShopID] ,[ShopName] ,[Currency] ,[Link] ," +
                $"[MinimumQuantity] ,[SellerID] ,[ItemID] ,[Site] ,[Title] ,[WangWang] ,[PriceStep] ,[Tool] ,[VersionTool]) " +
                $"OUTPUT INSERTED.Id INTO @InsertedIds " +
                $"VALUES ({currentDate},N'{currentUser.Username}',0,1,'{currentUser.UserId}'," +
                $"N'{request.ShopId}',N'{request.ShopName}',{request.Currency},N'{request.Link}'," +
                $"{request.MinimumQuantity},N'{request.SellerId}',N'{request.ItemId}',N'{request.Site}'," +
                $"N'{request.Title}',N'{request.WangWang}',N'{request.PriceStep}',N'{request.Tool}',N'{request.VersionTool}')" +
                $"DECLARE @SID uniqueidentifier = (SELECT Id FROM @InsertedIds)";
            for (int i = 0; i < request.Orders.Count; i++)
            {
                var order = request.Orders[i];
                query += $"INSERT INTO [dbo].[OrderTemp] ([Created] ,[CreatedBy], [Deleted] ,[Active] ," +
                    $"[OrderShopTempId] ,[Image] ,[PriceOrigin] ,[PricePromotion] ,[Properties] ,[Quantity] ,[SkuID]) " +
                    $"VALUES ({currentDate},N'{currentUser.Username}',0,1,@SID,N'{order.Image}'," +
                    $"{order.PriceOrigin},{order.PricePromotion},N'{order.Properties}',{order.Quantity},N'{order.SkuId}')";
            }   
            _unitOfWork.QueryRepository().ExecuteNonQuery(query);
            return true;
        }
    }
}
