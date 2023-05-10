using Application.Extensions;
using Application.Utilities;
using Domain.Common;
using Domain.Entities.DomainEntities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class DomainRepository<E> : IDomainRepository<E> where E : BaseEntity
    {
        protected readonly IAppDbContext _appDbContext;

        public DomainRepository(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Attach(E item)
        {
            _appDbContext.Set<E>().Attach(item);
            _appDbContext.Entry(item).State = EntityState.Unchanged;
        }

        public virtual async Task CreateAsync(E entity)
        {
            entity.Created = entity.Updated = Timestamp.Now();
            if (string.IsNullOrEmpty(entity.CreatedBy))
            {
                var User = LoginContext.Instance.CurrentUser;
                if (User != null)
                {
                    entity.CreatedBy = User.Username;
                }

            }
            await _appDbContext.Set<E>().AddAsync(entity);
        }

        public virtual async Task CreateAsync(IList<E> entities)
        {
            foreach (var entity in entities)
            {
                entity.Created = entity.Updated = Timestamp.Now();
                if (string.IsNullOrEmpty(entity.CreatedBy))
                {
                    var User = LoginContext.Instance.CurrentUser;
                    if (User != null)
                    {
                        entity.CreatedBy = User.Username;
                    }
                }
            }
            await _appDbContext.Set<E>().AddRangeAsync(entities);
        }

        public void Delete(E entity)
        {
            _appDbContext.Set<E>().Remove(entity);
        }

        public void Delete(IList<E> entities)
        {
            _appDbContext.Set<E>().RemoveRange(entities);
        }

        public void Detach(E entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Detached;
        }

        public Task<DataTable> ExcuteQueryAsync(string commandText, SqlParameter[] sqlParameters)
        {
            throw new NotImplementedException();
        }

        public Task<E> ExcuteQueryGetByIdAsync(string commandText, SqlParameter sqlParameter)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<E>> ExcuteQueryPagingAsync(string commandText, SqlParameter[] sqlParameters)
        {
            return Task.Run(() =>
            {
                PagedList<E> pagedList = new PagedList<E>();
                DataTable dataTable = new DataTable();
                SqlConnection connection = null;
                SqlCommand command = null;
                try
                {
                    connection = (SqlConnection)_appDbContext.Database.GetDbConnection();
                    command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = commandText;
                    command.Parameters.AddRange(sqlParameters);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    sqlDataAdapter.Fill(dataTable);
                    pagedList.Items = MappingDataTable.ConvertToList<E>(dataTable);
                    if (pagedList.Items != null && pagedList.Items.Any())
                        pagedList.TotalItem = pagedList.Items.Count;
                    return pagedList;
                }
                finally
                {
                    if (connection != null && connection.State == ConnectionState.Open)
                        connection.Close();

                    if (command != null)
                        command.Dispose();
                }
            });
        }

        public Task<IList<E>> ExcuteStoreAsync(string commandText, SqlParameter[] sqlParameters)
        {
            throw new NotImplementedException();
        }

        public Task<object> ExcuteStoreGetValue(string commandText, SqlParameter[] sqlParameters, string outputName)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string commandText, SqlParameter[] sqlParameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string commandText)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                connection = (SqlConnection)_appDbContext.Database.GetDbConnection();
                command = connection.CreateCommand();
                connection.Open();
                command.CommandText = commandText;
                return command.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();

                if (command != null)
                    command.Dispose();
            }
        }

        public IQueryable<E> GetQueryable()
        {
            return _appDbContext.Set<E>();
        }

        public void Update(E entity)
        {
            entity.Created = entity.Updated = Timestamp.Now();
            if (string.IsNullOrEmpty(entity.UpdatedBy))
            {
                var User = LoginContext.Instance.CurrentUser;
                if (User != null)
                {
                    entity.UpdatedBy = User.Username;
                }
            }
            _appDbContext.Set<E>().Update(entity);
        }

        public virtual async Task<bool> UpdateFieldsSaveAsync(E entity, params Expression<Func<E, object>>[] includeProperties)
        {
            entity.Updated = Timestamp.Now();
            if (string.IsNullOrEmpty(entity.UpdatedBy))
            {
                var User = LoginContext.Instance.CurrentUser;
                if (User != null)
                {
                    entity.UpdatedBy = User.Username;
                }

            }
            return await Task.Run(() =>
            {
                var dbEntry = _appDbContext.Entry(entity);

                foreach (var includeProperty in includeProperties)
                {
                    dbEntry.Property(includeProperty).IsModified = true;
                }
                return _appDbContext.SaveChanges() > 0;
            });
        }
    }
}
