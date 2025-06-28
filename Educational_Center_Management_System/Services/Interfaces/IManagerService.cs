using Educational_Center_Management_System.Models;

namespace Educational_Center_Management_System.Services.Interfaces
{
    internal interface IManagerService
    {
        public Task<bool> AddStudent(Student student); // done
        public Task<bool> DelelteStudent(int studentId); // not needed
        public Task<bool> UpdateStudent(Student student); // done
        public Task<Student?> GetStudent(int studentId); // done
        public Task<List<Student?>> GetAllStudents(); // done
        public Task<bool> AddTeacher(Teacher teacher); // done
        public Task<bool> DeleteTeacher(int teacherId); // not needed
        public Task<bool> UpdateTeacher(Teacher teacher); 
        public Task<Teacher?> GetTeacher(int teacherId); // done
        public Task<List<Teacher?>> GetAllTeachers();
        public Task<bool> CreateClass(Class newClass);
        public Task<bool> DeleteClass(int classId);
        public Task<bool> UpdateClass(Class updatedClass);
        public Task<Manager?> GetManager();
        public Task<bool> UpdataManager(Manager manager);
    }
}
