using Application.Utilities;
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
        public async Task<object> ExcuteStoreGetValue(string commandText, SqlParameter[] sqlParameters, SqlParameter outputParameter)
        {
            return await Task.Run(() =>
            {
                object obj = new object();
                DataTable dataTable = new DataTable();
                SqlConnection connection = null;
                SqlCommand command = null;
                try
                {
                    connection = (SqlConnection)_appDbContext.Database.GetDbConnection();
                    command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = commandText;
                    if (sqlParameters != null && sqlParameters.Length > 0)
                        command.Parameters.AddRange(sqlParameters);
                    command.Parameters.Add(outputParameter);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    sqlDataAdapter.Fill(dataTable);
                    var objectValue = command.Parameters[outputParameter.ParameterName].Value;
                    if (objectValue != null)
                        obj = objectValue;
                    return obj;
                }
                finally
                {
                    if (connection != null && connection.State == System.Data.ConnectionState.Open)
                        connection.Close();

                    if (command != null)
                        command.Dispose();
                }
            });
        }
        public async Task<string> ExcuteStoreNoneInput(string commandText, string ouput)
        {
            return await Task.Run(() =>
            {
                object obj = new object();
                DataTable dataTable = new DataTable();
                SqlConnection connection = null;
                SqlCommand command = null;
                try
                {
                    connection = (SqlConnection)_appDbContext.Database.GetDbConnection();
                    command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = commandText;
                    SqlParameter outputParameter = new SqlParameter(ouput, SqlDbType.NVarChar, int.MaxValue);
                    outputParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputParameter);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                    sqlDataAdapter.Fill(dataTable);
                    var objectValue = command.Parameters[ouput].Value;
                    if (objectValue != null)
                        obj = objectValue;
                    return obj.ToString();
                }
                finally
                {
                    if (connection != null && connection.State == System.Data.ConnectionState.Open)
                        connection.Close();

                    if (command != null)
                        command.Dispose();
                }
            });
        }
        public async Task<string> ExcuteStoreGetJsonData(string commandText, SqlParameter[] sqlParameters)
        {
            return await Task.Run(() =>
            {
                SqlData obj = new SqlData();
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
                    obj = MappingDataTable.ConvertToList<SqlData>(dataTable).FirstOrDefault();
                    return obj.Data.ToString();
                }
                finally
                {
                    if (connection != null && connection.State == System.Data.ConnectionState.Open)
                        connection.Close();

                    if (command != null)
                        command.Dispose();
                }
            });
        }

        public class SqlData
        {
            public string Data { get; set; }
        }
    }
}
