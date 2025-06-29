using Educational_Center_Management_System.Models;
using Microsoft.Data.SqlClient;

namespace Educational_Center_Management_System.DataAccessLayer.Repositories.ManagerRepositories
{
    public class TeacherManagerService
    {
        public async Task<bool> AddTeacher(Teacher teacher)
        {
            using SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "INSERT INTO Teachers VALUES (@Name, @LastName, @FatherName, @BirthDate, @Photo, @PhoneNumber, @JoinDate, @LeaveDate, @State, @Password)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", teacher.Name);
            command.Parameters.AddWithValue("@LastName", teacher.LastName);
            command.Parameters.AddWithValue("FatherName", teacher.Fathername);
            command.Parameters.AddWithValue("BirthDate", teacher.BirthDate.ToDateTime(TimeOnly.MinValue));
            var parameter = command.Parameters.Add("@Photo", System.Data.SqlDbType.VarBinary);
            parameter.Value = (object?)teacher.Photo ?? DBNull.Value; // Handle null photo
            command.Parameters.AddWithValue("@PhoneNumber", teacher.PhoneNumber);
            command.Parameters.AddWithValue("@JoinDate", teacher.JoinDate.ToDateTime(TimeOnly.MinValue));
            command.Parameters.AddWithValue("@LeaveDate", DBNull.Value);
            command.Parameters.AddWithValue("@State", teacher.State);
            command.Parameters.AddWithValue("@Password", teacher.Password);

            int rowsEffected = await command.ExecuteNonQueryAsync();
            return rowsEffected > 0;
        }
        public async Task<bool> DeleteTeacher(int teacherId)
        {
            using SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "DELETE FROM Teachers WHERE t_id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", teacherId);

            int rowEffected = await command.ExecuteNonQueryAsync();
            return rowEffected > 0;
        }
        public async Task<bool> UpdateTeacher(Teacher UpdatedTeacher)
        {
            using SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "UPDATE Teachers SET t_name = @Name, t_last_name = @LastName, t_father_name = @FatherName, " +
                           "t_date_of_birth = @BirthDate, t_photo = @Photo, t_phone_number = @PhoneNumber, " +
                           "t_join_date = @JoinDate, t_leave_date = @LeaveDate, t_state = @State, t_password = @Password WHERE t_id = @Id";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", UpdatedTeacher.Id);
            command.Parameters.AddWithValue("@Name", UpdatedTeacher.Name);
            command.Parameters.AddWithValue("@LastName", UpdatedTeacher.LastName);
            command.Parameters.AddWithValue("@FatherName", UpdatedTeacher.Fathername);
            command.Parameters.AddWithValue("@BirthDate", UpdatedTeacher.BirthDate.ToDateTime(TimeOnly.MinValue));
            var parameter = command.Parameters.Add("@Photo", System.Data.SqlDbType.VarBinary);
            parameter.Value = (object?)UpdatedTeacher.Photo ?? DBNull.Value; // Handle null photo
            command.Parameters.AddWithValue("@PhoneNumber", UpdatedTeacher.PhoneNumber);
            command.Parameters.AddWithValue("@JoinDate", UpdatedTeacher.JoinDate.ToDateTime(TimeOnly.MinValue));
            command.Parameters.AddWithValue("@LeaveDate", DBNull.Value);
            command.Parameters.AddWithValue("@State", UpdatedTeacher.State);
            command.Parameters.AddWithValue("@Password", UpdatedTeacher.Password);

            int rowsEffected = await command.ExecuteNonQueryAsync();
            return rowsEffected > 0;
        }
        public async Task<Teacher?> GetTeacher(int teacherId)
        {
            SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "SELECT * FROM Teachers WHERE t_id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", teacherId);

            SqlDataReader reader = command.ExecuteReader();
            if (await reader.ReadAsync())
            {
                return new Teacher
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Fathername = reader.GetString(3),
                    BirthDate = DateOnly.FromDateTime(reader.GetDateTime(4)),
                    Photo = reader.IsDBNull(5) ? null : (byte[])reader[5],
                    PhoneNumber = reader.GetString(6),
                    JoinDate = DateOnly.FromDateTime(reader.GetDateTime(7)),
                    LeaveDate = reader.IsDBNull(8) ? null : DateOnly.FromDateTime(reader.GetDateTime(8)),
                    State = reader.GetInt32(9),
                    Password = reader.GetString(10)
                };
            }
            return null;
        }
        public async Task<List<Teacher?>> GetAllTeachers()
        {
            SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "SELECT * FROM Teachers";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = await command.ExecuteReaderAsync();
            List<Teacher?> teachers = new List<Teacher?>();
            while (reader.Read())
            {
                teachers.Add(new Teacher()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Fathername = reader.GetString(3),
                    BirthDate = DateOnly.FromDateTime(reader.GetDateTime(4)),
                    Photo = reader.IsDBNull(5) ? null : (byte[])reader[5],
                    PhoneNumber = reader.GetString(6),
                    JoinDate = DateOnly.FromDateTime(reader.GetDateTime(7)),
                    LeaveDate = reader.IsDBNull(8) ? null : DateOnly.FromDateTime(reader.GetDateTime(8)),
                    State = reader.GetInt32(9),
                    Password = reader.GetString(10)
                });
            }
            return teachers;
        }
    }
}
