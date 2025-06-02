using Educational_Center_Management_System.Models;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;

namespace Educational_Center_Management_System.DataAccessLayer.Repositories.ManagerRepositories
{
    public class StudentManagerService
    {
        public async Task<bool> AddStudent(Student student)
        {
            using SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "INSERT INTO Students VALUES (@Name, @LastName, @FatherName, @BirthDate, @Photo, @PhoneNumber, @JoinDate, @State, @Password)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", student.Name);
            command.Parameters.AddWithValue("@LastName", student.LastName);
            command.Parameters.AddWithValue("FatherName", student.Fathername);
            command.Parameters.AddWithValue("BirthDate", student.BirthDate.ToDateTime(TimeOnly.MinValue));
            var parameter = command.Parameters.Add("@Photo", System.Data.SqlDbType.VarBinary);
            parameter.Value = (object?) student.Photo ?? DBNull.Value; // Handle null photo
            command.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
            command.Parameters.AddWithValue("@JoinDate", student.JoinDate.ToDateTime(TimeOnly.MinValue));
            command.Parameters.AddWithValue("@State", student.State);
            command.Parameters.AddWithValue("@Password", student.Password);

            int rowEffected = await command.ExecuteNonQueryAsync();
            return rowEffected > 0;
        }
        public async Task<bool> DeleteStudent(int studentId)
        {
            using SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "DELETE FROM Students WHERE s_id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", studentId);

            int rowEffected = await command.ExecuteNonQueryAsync();
            return rowEffected > 0;
        }
        public async Task<bool> UpdateStudent(Student UpdatedStudent)
        {
            using SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "UPDATE Students SET s_name = @Name, s_last_name = @LastName, s_father_name = @FatherName, " +
                           "s_date_of_birth = @BirthDate, s_photo = @Photo, s_phone_number = @PhoneNumber, " +
                           "s_join_date = @JoinDate, s_state = @State, s_password = @Password WHERE s_id = @Id";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", UpdatedStudent.Id);
            command.Parameters.AddWithValue("@Name", UpdatedStudent.Name);
            command.Parameters.AddWithValue("@LastName", UpdatedStudent.LastName);
            command.Parameters.AddWithValue("@FatherName", UpdatedStudent.Fathername);
            command.Parameters.AddWithValue("@BirthDate", UpdatedStudent.BirthDate.ToDateTime(TimeOnly.MinValue));
            var parameter = command.Parameters.Add("@Photo", System.Data.SqlDbType.VarBinary);
            parameter.Value = (object?)UpdatedStudent.Photo ?? DBNull.Value; // Handle null photo
            command.Parameters.AddWithValue("@PhoneNumber", UpdatedStudent.PhoneNumber);
            command.Parameters.AddWithValue("@JoinDate", UpdatedStudent.JoinDate.ToDateTime(TimeOnly.MinValue));
            command.Parameters.AddWithValue("@State", UpdatedStudent.State);
            command.Parameters.AddWithValue("@Password", UpdatedStudent.Password);

            int rowEffected = await command.ExecuteNonQueryAsync();
            return rowEffected > 0;
        }
        public async Task<Student?> GetStudent(int studentId)
        {
            SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "SELECT * FROM Students WHERE s_id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", studentId);

            SqlDataReader reader = command.ExecuteReader();
            if (await reader.ReadAsync())
            {
                return new Student
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Fathername = reader.GetString(3),
                    BirthDate = DateOnly.FromDateTime(reader.GetDateTime(4)),
                    Photo = reader.IsDBNull(5) ? null : (byte[])reader[5],
                    PhoneNumber = reader.GetString(6),
                    JoinDate = DateOnly.FromDateTime(reader.GetDateTime(7)),
                    State = reader.GetInt32(8),
                    Password = reader.GetString(9)
                };
            }
            return null;
        }
        public async Task<List<Student?>> GetAllStudents()
        {
            SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "SELECT * FROM Students";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = await command.ExecuteReaderAsync();
            List<Student?> students = new List<Student?>();
            while (reader.Read())
            {
                students.Add(new Student()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Fathername = reader.GetString(3),
                    BirthDate = DateOnly.FromDateTime(reader.GetDateTime(4)),
                    Photo = reader.IsDBNull(5) ? null : (byte[])reader[5],
                    PhoneNumber = reader.GetString(6),
                    JoinDate = DateOnly.FromDateTime(reader.GetDateTime(7)),
                    State = reader.GetInt32(8),
                    Password = reader.GetString(9)
                });
            }
            return students;
        }
    }
}
