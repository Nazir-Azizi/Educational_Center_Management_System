using Educational_Center_Management_System.DataAccessLayer.Repositories.ManagerRepositories;
using Educational_Center_Management_System.Models;
using Educational_Center_Management_System.Services.Interfaces;

namespace Educational_Center_Management_System.Services
{
    public sealed class ManagerService : IManagerService
    {
        private readonly StudentManagerService _studentManagerService;
        private readonly TeacherManagerService _teacherManagerService;
        private readonly ClassManagerService _classManagerService;
        private readonly ManagerDAO _managerDAO;

        public ManagerService()
        {
            _studentManagerService = new StudentManagerService();
            _teacherManagerService = new TeacherManagerService();
            _classManagerService = new ClassManagerService();
            _managerDAO = new ManagerDAO();
        }

        public Task<bool> DelelteStudent(int studentId)
        {
            return _studentManagerService.DeleteStudent(studentId);
        }

        public Task<bool> DeleteClass(int classId)
        {
            return _classManagerService.DeleteClass(classId);
        }

        public Task<bool> DeleteTeacher(int teacherId)
        {
            return _teacherManagerService.DeleteTeacher(teacherId);
        }

        public Task<bool> AddStudent(Student student)
        {
            return _studentManagerService.AddStudent(student);
        }

        public Task<bool> AddTeacher(Teacher teacher)
        {
            return _teacherManagerService.AddTeacher(teacher);
        }

        public Task<bool> CreateClass(Class newClass)
        {
            return _classManagerService.CreateClass(newClass);
        }

        public Task<List<Student?>> GetAllStudents()
        {
            return _studentManagerService.GetAllStudents();
        }

        public Task<List<Teacher?>> GetAllTeachers()
        {
            return _teacherManagerService.GetAllTeachers();
        }

        public Task<Student?> GetStudent(int studentId)
        {
            return _studentManagerService.GetStudent(studentId);
        }

        public Task<Teacher?> GetTeacher(int teacherId)
        {
            return _teacherManagerService.GetTeacher(teacherId);
        }

        public Task<bool> UpdateClass(Class updatedClass)
        {
            return _classManagerService.UpdateClass(updatedClass);
        }

        public Task<bool> UpdateStudent(Student student)
        {
            return _studentManagerService.UpdateStudent(student);
        }

        public Task<bool> UpdateTeacher(Teacher teacher)
        {
            return _teacherManagerService.UpdateTeacher(teacher);
        }

        public Task<Manager?> GetManager()
        {
            return _managerDAO.GetManager();   
        }

        public Task<bool> UpdataManager(Manager manager)
        {
            return _managerDAO.UpdataManager(manager);
        }
    }
}
