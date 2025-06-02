using Educational_Center_Management_System.Models;
using Educational_Center_Management_System.Services.Interfaces;
using Educational_Center_Management_System.DataAccessLayer.Repositories.StudentRepositories;
namespace Educational_Center_Management_System.Services
{
    internal class StudentService : IStudentService
    {
        private StudentServiceRepository _studentSeriviceRepository;
        public StudentService()
        {
            _studentSeriviceRepository = new StudentServiceRepository();
        }
        public Class GetClass(int studentId)
        {
            return _studentSeriviceRepository.GetClass(studentId);
        }

        public List<Score> GetScore(int studentId)
        {
            return _studentSeriviceRepository.GetScore(studentId);
        }
    }
}
