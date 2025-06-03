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
        public Task<List<Class>> GetClass(int studentId)
        {
            return _studentSeriviceRepository.GetClass(studentId);
        }

        public Task<List<ScoreForDisplay>> GetScore(int studentId)
        {
            return _studentSeriviceRepository.GetScore(studentId);
        }
    }
}
