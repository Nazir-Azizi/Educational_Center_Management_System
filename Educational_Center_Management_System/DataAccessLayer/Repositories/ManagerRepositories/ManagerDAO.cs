using Educational_Center_Management_System.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational_Center_Management_System.DataAccessLayer.Repositories.ManagerRepositories
{
    public class ManagerDAO
    {
        public async Task<Manager?> GetManager()
        {
            using SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "SELECT * FROM Managers";
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = await command.ExecuteReaderAsync();
            if (reader.Read())
            {
                return new Manager()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Photo = reader.IsDBNull(3) ? null : (byte[])reader[3],
                    Password = reader.GetString(4)
                };
            }
            return null;
        }
        public async Task<bool> UpdataManager(Manager manager)
        {
            using SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "UPDATE Managers SET manager_name = @Name, manager_last_name = @LastName,"
                + "manager_photo = @Photo, manager_password = @Password;";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", manager.Name);
            command.Parameters.AddWithValue("@LastName", manager.LastName);
            var parameter = command.Parameters.Add("@Photo", System.Data.SqlDbType.VarBinary);
            parameter.Value = (object?)manager.Photo ?? DBNull.Value; // Handle null photo
            command.Parameters.AddWithValue("@Password", manager.Password);

            int rowEffected = await command.ExecuteNonQueryAsync();
            return rowEffected > 0;
        }
    }
}
