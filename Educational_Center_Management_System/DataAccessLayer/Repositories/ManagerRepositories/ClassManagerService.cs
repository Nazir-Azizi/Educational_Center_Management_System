﻿using Educational_Center_Management_System.Models;
using Microsoft.Data.SqlClient;


namespace Educational_Center_Management_System.DataAccessLayer.Repositories.ManagerRepositories
{
    public class ClassManagerService
    {
        public async Task<bool> CreateClass(Class newClass)
        {
            using SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "INSERT INTO Classes VALUES (@ClassState, @ClassTeacher, @ClassSemester, @ClassName, @ClassTime, @ClassDate)";
            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassState", newClass.State);
            command.Parameters.AddWithValue("@ClassTeacher", newClass.Teacher);
            command.Parameters.AddWithValue("@ClassSemester", newClass.Semester);
            command.Parameters.AddWithValue("@ClassName", newClass.Name);
            command.Parameters.AddWithValue("@ClassTime", newClass.Time);
            command.Parameters.AddWithValue("@ClassDate", newClass.Date.ToDateTime(TimeOnly.MinValue));

            int rowEffected = await command.ExecuteNonQueryAsync();
            return rowEffected > 0;
        }
        public async Task<bool> DeleteClass(int classId)
        {
            using SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "DELETE FROM Classes WHERE class_id = @ClassId";
            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassId", classId);
            int rowEffected = await command.ExecuteNonQueryAsync();
            return rowEffected > 0;
        }
        public async Task<bool> UpdateClass(Class updatedClass)
        {
            using SqlConnection connection = await DatabaseConnectionManager.Instance.GetOpenConnectionAsync();
            string query = "UPDATE Classes SET class_state = @ClassState, class_teacher = @ClassTeacher, " +
                           "class_semester = @ClassSemester, class_name = @ClassName, class_time = @ClassTime, " +
                           "class_date = @ClassDate WHERE class_id = @ClassId";
            using SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@ClassState", updatedClass.State);
            command.Parameters.AddWithValue("@ClassTeacher", updatedClass.Teacher);
            command.Parameters.AddWithValue("@ClassSemester", updatedClass.Semester);
            command.Parameters.AddWithValue("@ClassName", updatedClass.Name);
            command.Parameters.AddWithValue("@ClassTime", updatedClass.Time);
            command.Parameters.AddWithValue("@ClassDate", updatedClass.Date.ToDateTime(TimeOnly.MinValue));
            command.Parameters.AddWithValue("@ClassId", updatedClass.Id);

            int rowEffected = await command.ExecuteNonQueryAsync();
            return rowEffected > 0;
        }
    }
}
