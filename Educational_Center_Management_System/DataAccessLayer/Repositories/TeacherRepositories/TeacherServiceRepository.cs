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
    }
}
