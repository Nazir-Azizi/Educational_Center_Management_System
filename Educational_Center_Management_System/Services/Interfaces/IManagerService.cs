using Educational_Center_Management_System.Models;


namespace Educational_Center_Management_System.Services.Interfaces
{
    internal interface IManagerService
    {
        public bool AddStudent(Student student);
        public bool DelelteStudent(int studentId);
        public bool UpdateStudent(Student student);
        public Student? GetStudent(int studentId);
        public List<Student> GetAllStudents();
        public bool AddTeacher(Teacher teacher);
        public bool DeleteTeacher(int teacherId);
        public bool UpdateTeacher(Teacher teacher);
        public Teacher GetTeacher(int teacherId);
        public List<Teacher> GetAllTeachers();
        public bool CreateClass(Class newClass);
        public bool DeleteClass(int classId);
        public bool UpdateClass(Class updatedClass);
    }
}
