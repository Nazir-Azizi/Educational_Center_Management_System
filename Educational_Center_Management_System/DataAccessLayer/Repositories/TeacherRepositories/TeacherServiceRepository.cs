using Educational_Center_Management_System.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Educational_Center_Management_System.DataAccessLayer.Repositories.TeacherRepositories
{
    public class TeacherServiceRepository
    {
        public async Task<List<Class>> GetClasses(int teacherId)
        {
            SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "SELECT c.class_id, c.class_state, c.class_semester, c.class_name, "
                + "c.class_time, c.class_date FROM Classes c JOIN Teachers t ON c.class_teacher = t_id WHERE t_id = @Id";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", teacherId);
            SqlDataReader reader = await command.ExecuteReaderAsync();
            List<Class> classes = new List<Class>();

            while(reader.Read())
            {
                classes.Add(new Class()
                {
                    Id = reader.GetInt32(0),
                    State = reader.GetInt32(1),
                    Teacher = -1,
                    Semester = reader.GetString(2),
                    Name = reader.GetString(3),
                    Time = reader.GetTimeSpan(4),
                    Date = DateOnly.FromDateTime(reader.GetDateTime(5))
                });
            }
            return classes;
        }

        public async Task<bool> SetScore(Score score)
        {
            SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "INSERT INTO Scores VALUES (@StudentId, @ClassId, @Number)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentId", score.StudentId);
            command.Parameters.AddWithValue("@ClassId", score.ClassId);
            command.Parameters.AddWithValue("@Number", score.Number);

            int rowsEffected = await command.ExecuteNonQueryAsync();
            return rowsEffected > 0;
        }

        public async Task<bool> UpdateScore(Score UpdatedScore)
        {
            SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "UPDATE Scores set st_id = @StudentId, class_id = @ClassId, score = @Number WHERE score_id = @ScoreId";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentId", UpdatedScore.StudentId);
            command.Parameters.AddWithValue("@ClassId", UpdatedScore.ClassId);
            command.Parameters.AddWithValue("@Number", UpdatedScore.Number);
            command.Parameters.AddWithValue("@ScoreId", UpdatedScore.Id);

            int rowsEffected = await command.ExecuteNonQueryAsync();
            return rowsEffected > 0;
        }
        public async Task<List<Student>> GetStudentsOfClass(int classId)
        {
            SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "SELECT st.s_id, st.s_name, st.s_last_name, st.s_father_name, st.s_date_of_birth, "
                + "st.s_photo, st.s_phone_number, st.s_join_date, st.s_state, st.s_password " 
                + "FROM StudentClassRelationship "
                + "JOIN Students st ON StudentClassRelationship.st_id = st.s_id "
                + "JOIN Classes ON StudentClassRelationship.class_id = Classes.class_id "
                + "WHERE Classes.class_id = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", classId);
            SqlDataReader reader = await command.ExecuteReaderAsync();
            List<Student> students = new List<Student>();

            while(reader.Read())
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
        public async Task<Score?> GetStudentScore(int studentId, int classId)
        {
            SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "SELECT * FROM Scores WHERE class_id = @classId AND st_id = @studentId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@classId", classId);
            command.Parameters.AddWithValue("@studentId", studentId);
            SqlDataReader reader = await command.ExecuteReaderAsync();

            while(reader.Read())
            {
                return new Score
                {
                    Id = reader.GetInt32(0),
                    StudentId = reader.GetInt32(1),
                    ClassId = reader.GetInt32(2),
                    Number = reader.GetDecimal(3)
                };
            }
            return null;
        }
    }
}
