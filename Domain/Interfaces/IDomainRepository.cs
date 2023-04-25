using Domain.Common;
using Domain.Entities.DomainEntities;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IDomainRepository<E> where E : BaseEntity
    {
        IQueryable<E> GetQueryable();
        Task CreateAsync(E entity);
        Task CreateAsync(IList<E> entities);
        void Update(E entity);
        void Delete(E entity);
        void Delete(IList<E> entities);
        void Attach(E item);
        void Detach(E entity);
        //int ExecuteNonQuery(string commandText, SqlParameter[] sqlParameters);
        //int ExecuteNonQuery(string commandText);
        //Task<DataTable> ExcuteQueryAsync(string commandText, SqlParameter[] sqlParameters);
        Task<PagedList<E>> ExcuteQueryPagingAsync(string commandText, SqlParameter[] sqlParameters);
        Task<E> ExcuteQueryGetByIdAsync(string commandText, SqlParameter sqlParameter);
        Task<IList<E>> ExcuteStoreAsync(string commandText, SqlParameter[] sqlParameters);
        //Task<object> ExcuteStoreGetValue(string commandText, SqlParameter[] sqlParameters, string outputName);
        Task<bool> UpdateFieldsSaveAsync(E entity, params Expression<Func<E, object>>[] includeProperties);
    }
}
