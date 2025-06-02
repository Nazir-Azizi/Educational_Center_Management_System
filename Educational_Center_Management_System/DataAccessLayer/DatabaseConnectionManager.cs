using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Educational_Center_Management_System.DataAccessLayer
{
    public sealed class DatabaseConnectionManager
    {
        private readonly string _connectionString;
        private static readonly Lazy<DatabaseConnectionManager> _instance
            = new (() => new DatabaseConnectionManager());
        public static DatabaseConnectionManager Instance => _instance.Value;

        private DatabaseConnectionManager()
        {
            _connectionString = "Server=localhost;Database=Educational_Center_Management_System;Trusted_Connection=True;TrustServerCertificate=True;";
        }
        public async Task<SqlConnection> GetOpenConnectionAsync()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            try
            {
                await connection.OpenAsync();
                return connection;
            }
            catch
            {
                connection.Dispose();
                throw;
            }
        }
    }
}
