using Educational_Center_Management_System.Models;


namespace Educational_Center_Management_System.Services.Interfaces
{
    internal interface IStudentService
    {
        public Class GetClass(int studentId);
        public List<Score> GetScore(int studentId);
    }
}
