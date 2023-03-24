using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infrastructure.Services
{
    public class QueryRepository : IQueryRepository
    {
        protected readonly AppDbContext _appDbContext;
        public QueryRepository(AppDbContext appDbContext)
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
                if (connection != null && connection.State != System.Data.ConnectionState.Closed)
                    connection.Close();
                command = connection.CreateCommand();
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                command.CommandText = commandText;
                return command.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                    connection.Close();

                if (command != null)
                    command.Dispose();
            }
        }
    }
}
