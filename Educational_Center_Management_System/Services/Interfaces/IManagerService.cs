using Educational_Center_Management_System.Models;


namespace Educational_Center_Management_System.Services.Interfaces
{
    internal interface IManagerService
    {
        public Task<bool> AddStudent(Student student);
        public Task<bool> DelelteStudent(int studentId);
        public Task<bool> UpdateStudent(Student student);
        public Task<Student?> GetStudent(int studentId);
        public Task<List<Student?>> GetAllStudents();
        public Task<bool> AddTeacher(Teacher teacher);
        public Task<bool> DeleteTeacher(int teacherId);
        public Task<bool> UpdateTeacher(Teacher teacher);
        public Task<Teacher?> GetTeacher(int teacherId);
        public Task<List<Teacher?>> GetAllTeachers();
        public Task<bool> CreateClass(Class newClass);
        public Task<bool> DeleteClass(int classId);
        public Task<bool> UpdateClass(Class updatedClass);
    }
}
