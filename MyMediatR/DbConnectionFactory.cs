using Microsoft.Data.SqlClient;
using System.Data;

namespace MyMediatR
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }

    public class DbConnectionFactory(IConfiguration configuration) : IDbConnectionFactory
    {
        private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Строка подключения не найдена");

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
