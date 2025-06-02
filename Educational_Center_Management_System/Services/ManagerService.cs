using Educational_Center_Management_System.DataAccessLayer.Repositories.ManagerRepositories;
using Educational_Center_Management_System.Models;
using Educational_Center_Management_System.Services.Interfaces;

namespace Educational_Center_Management_System.DataAccessLayer
{
    public sealed class ManagerService : IManagerService
    {
        private readonly StudentManagerService _studentManagerService;
        private readonly TeacherManagerService _teacherManagerService;
        private readonly ClassManagerService _classManagerService;


        public ManagerService()
        {
            _studentManagerService = new StudentManagerService();
            _teacherManagerService = new TeacherManagerService();
            _classManagerService = new ClassManagerService();
        }

        public bool DelelteStudent(int studentId)
        {
            //return _studentManagerService.DeleteStudent(studentId);
            return false;
        }

        public bool DeleteClass(int classId)
        {
            //return await _classManagerService.DeleteClass(classId);
            return false;
        }

        public bool DeleteTeacher(int teacherId)
        {
            //return _teacherManagerService.DeleteTeacher(teacherId);
            return false;
        }

        public bool AddStudent(Student student)
        {
            //return _studentManagerService.AddStudent(student);
            return false; // Placeholder for actual implementation
        }

        public bool AddTeacher(Teacher teacher)
        {
            //return _teacherManagerService.AddTeacher(teacher);
            return false;
        }

        public bool CreateClass(Class newClass)
        {
            //return _classManagerService.CreateClass(newClass);
            return false;
        }

        public List<Student> GetAllStudents()
        {
            //return _studentManagerService.GetAllStudents();
            return new List<Student>(); // Placeholder for actual implementation
        }

        public List<Teacher> GetAllTeachers()
        {
            //return _teacherManagerService.GetAllTeachers();
            return new List<Teacher>();
        }

        public Student? GetStudent(int studentId)
        {
            //return _studentManagerService.GetStudent(studentId);
            return null;
        }

        public Teacher? GetTeacher(int teacherId)
        {
            //return _teacherManagerService.GetTeacher(teacherId);
            return null;
        }

        public bool UpdateClass(Class updatedClass)
        {
            //return _classManagerService.UpdateClass(updatedClass);
            return false;
        }

        public bool UpdateStudent(Student student)
        {
            //return _studentManagerService.UpdateStudent(student);
            return false;
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            //return _teacherManagerService.UpdateTeacher(teacher);
            return false;
        }
    }
}
