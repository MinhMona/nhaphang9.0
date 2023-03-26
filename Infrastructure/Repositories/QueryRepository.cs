using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infrastructure.Repositories
{
    public class QueryRepository : IQueryRepository
    {
        protected readonly IAppDbContext _appDbContext;
        public QueryRepository(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int ExecuteNonQuery(string commandText)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                connection = (SqlConnection)_appDbContext.Database.GetDbConnection();
                if (connection != null && connection.State != ConnectionState.Closed)
                    connection.Close();
                command = connection.CreateCommand();
                if (connection.State != ConnectionState.Open)
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
    }
}
