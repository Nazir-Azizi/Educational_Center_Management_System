using Educational_Center_Management_System.DataAccessLayer.Repositories.StudentRepositories;
using Educational_Center_Management_System.Models;
using Xunit;

namespace Educational_Center_Management_System.Test.DateAccessLayer.Repositories.StudentRepositories
{
    public class StudentServiceRepositoryTest
    {
        [Fact]
        public async void GetClass_ShouldReturnStudentClasses_WhenCalled()
        {
            StudentServiceRepository studentServiceRepository = new StudentServiceRepository();
            List<Class> cLasses = await studentServiceRepository.GetClass(1);
            Assert.Equal(2, cLasses.Count);

        }
        [Fact]
        public async void GetScore_ShouldReturnAllStudentScore_WhenCalled()
        {
            StudentServiceRepository studentServiceRepository = new StudentServiceRepository();
            List<ScoreForDisplay> scores = await studentServiceRepository.GetScore(1);
            Assert.Equal(1, scores.Count);
        }
    }
}
