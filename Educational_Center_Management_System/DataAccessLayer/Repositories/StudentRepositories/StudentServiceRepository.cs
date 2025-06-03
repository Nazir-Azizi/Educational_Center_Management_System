using Educational_Center_Management_System.Models;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography.Xml;

namespace Educational_Center_Management_System.DataAccessLayer.Repositories.StudentRepositories
{
    public class StudentServiceRepository
    {
        public async Task<List<Class>> GetClass(int studentId)
        {
            SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "SELECT c.class_id, c.class_state, c.class_teacher, " + 
                "c.class_semester, c.class_name, c.class_time, c.class_date " + 
                " FROM StudentClassRelationship scr JOIN Students s " + 
                "ON s.s_id = scr.st_id JOIN Classes c ON scr.class_id = c.class_id";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = await command.ExecuteReaderAsync();
            List<Class> classes = new List<Class>();
            while(reader.Read())
            {
                classes.Add(new Class()
                {
                    Id = reader.GetInt32(0),
                    State = reader.GetInt32(1),
                    Teacher = reader.GetInt32(2),
                    Semester = reader.GetString(3),
                    Name = reader.GetString(4),
                    Time = reader.GetTimeSpan(5),
                    Date = DateOnly.FromDateTime(reader.GetDateTime(6))
                });
            }
            return classes;
        }

        public async Task<List<ScoreForDisplay>> GetScore(int studentId)
        {
            SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "SELECT c.class_id, c.class_name, s.score, t.t_name, c.class_date FROM Scores s "
                + "JOIN Students st ON @Id = st.s_id "
                + "JOIN Classes c ON c.class_id = s.class_id "
                + "JOIN Teachers t ON c.class_teacher = t.t_id;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", studentId);
            SqlDataReader reader = await command.ExecuteReaderAsync();
            List<ScoreForDisplay> scores = new List<ScoreForDisplay>();

            while(reader.Read())
            {
                scores.Add(new ScoreForDisplay()
                {
                    ClassId = reader.GetInt32(0),
                    ClassName = reader.GetString(1),
                    Number = reader.GetDecimal(2),
                    TeacherName = reader.GetString(3),
                    ClassDate = DateOnly.FromDateTime(reader.GetDateTime(4))
                });
            }
            return scores;
        }
    }
}
