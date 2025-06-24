using Educational_Center_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational_Center_Management_System.Services.Interfaces
{
    internal interface ITeacherService
    {
        public Task<List<Class>> GetClasses(int teacherId);
        public Task<bool> SetScore(Score score);
        public Task<bool> UpdateScore(Score score);
        public Task<List<Student>> GetStudentsOfClass(int classId);
        public Task<Score?> GetStudentScore(int studentId, int classId);
    }
}
