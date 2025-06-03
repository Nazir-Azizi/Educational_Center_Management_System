using Educational_Center_Management_System.Models;


namespace Educational_Center_Management_System.Services.Interfaces
{
    internal interface IStudentService
    {
        public Task<List<Class>> GetClass(int studentId);
        public Task<List<ScoreForDisplay>> GetScore(int studentId);
    }
}
