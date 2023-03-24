using Application.Utilities;
using AutoMapper;
using Domain.Common;
using Domain.Entities.DomainEntities;
using Domain.Interfaces;
using Domain.Requests.DomainRequests;
using Domain.Searchs.DomainSearchs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Services
{
    public abstract class DomainService<E, R, S> : IDomainService<E, R, S> where E : BaseEntity where R : BaseRequest where S : BaseSearch, new()
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected IQueryable<E> Queryable
        {
            get
            {
                return _unitOfWork.Repository<E>().GetQueryable().AsNoTracking();
            }
        }
        public DomainService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public virtual async Task<bool> CreateAsync(R request)
        {
            return await CreateAsync(new List<R> { request });
        }

        public virtual async Task<bool> CreateAsync(IList<R> requests)
        {
            foreach (var item in requests)
            {
                E entity = _mapper.Map<E>(item);
                await _unitOfWork.Repository<E>().CreateAsync(entity);
            }
            return await _unitOfWork.Complete();
        }

        public virtual async Task<E> GetByIdAsync(Guid id)
        {
            E entity = await Queryable.Where(e => e.Id == id && !e.Deleted).AsNoTracking().FirstOrDefaultAsync();
            if(entity == null)
                throw new KeyNotFoundException("Entity not exist");
            return entity;
        }
        public virtual async Task<bool> UpdateAsync(R request)
        {
            return await UpdateAsync(new List<R> { request });
        }

        public virtual async Task<bool> UpdateAsync(IList<R> requests)
        {
            foreach (var item in requests)
            {
                var exist = await Queryable
                 .AsNoTracking()
                 .Where(e => e.Id == item.Id && !e.Deleted)
                 .FirstOrDefaultAsync();
                if (exist != null)
                {
                    var currentCreated = exist.Created;
                    var currentCreatedByInfo = exist.CreatedBy;
                    exist = _mapper.Map<E>(item);
                    exist.Created = currentCreated;
                    exist.CreatedBy = currentCreatedByInfo;
                    _unitOfWork.Repository<E>().Update(exist);
                }
            }
            return await _unitOfWork.Complete();
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            var exists = Queryable
                .AsNoTracking()
                .FirstOrDefault(e => e.Id == id);
            if (exists == null)
                throw new KeyNotFoundException("Entity not exist");
            exists.Deleted = true;
            _unitOfWork.Repository<E>().Update(exists);
            return await _unitOfWork.Complete();
        }

        public virtual async Task<PagedList<E>> GetPagedListData(S baseSearch)
        {
            PagedList<E> pagedList = new PagedList<E>();
            SqlParameter[] parameters = GetSqlParameters(baseSearch);
            pagedList = await _unitOfWork.Repository<E>().ExcuteQueryPagingAsync(this.GetStoreProcName(), parameters);
            pagedList.PageIndex = baseSearch.PageIndex;
            pagedList.PageSize = baseSearch.PageSize;
            return pagedList;
        }

        protected virtual SqlParameter[] GetSqlParameters(S baseSearch)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            foreach (PropertyInfo prop in baseSearch.GetType().GetProperties())
            {
                sqlParameters.Add(new SqlParameter(prop.Name, prop.GetValue(baseSearch, null)));
            }
            SqlParameter[] parameters = sqlParameters.ToArray();
            return parameters;
        }

        protected virtual string GetStoreProcName()
        {
            return string.Empty;
        }
    }
}
