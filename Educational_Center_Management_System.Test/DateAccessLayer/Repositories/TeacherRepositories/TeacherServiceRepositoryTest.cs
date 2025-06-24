using Educational_Center_Management_System.DataAccessLayer.Repositories.TeacherRepositories;
using Educational_Center_Management_System.Models;

namespace Educational_Center_Management_System.Test.DateAccessLayer.Repositories.TeacherRepositories
{
    public class TeacherServiceRepositoryTest
    {
        [Fact]
        public async void GetClasses_ShouldReturnTeacherClasses_WhenCalled()
        {
            TeacherServiceRepository teacherServiceRepository = new TeacherServiceRepository();
            List<Class> classes = await teacherServiceRepository.GetClasses(1);
            Assert.Equal(2, classes.Count);
        }
        [Fact]
        public async void SetScore_ShouldReturnTrue_WhenScoreIsSetSuccessfully()
        {
            TeacherServiceRepository teacherServiceRepository = new TeacherServiceRepository();
            Score score = new Score()
            {
                StudentId = 1,
                ClassId = 7,
                Number = 80.4
            };
            bool res = await teacherServiceRepository.SetScore(score);
            Assert.True(res, "Score is set successfully");
        }
        [Fact]
        public async void UpdateScore_ShouldReturnTrue_WhenScoreIsUpdated()
        {
            TeacherServiceRepository teacherServiceRepository = new TeacherServiceRepository();
            Score score = new Score()
            {
                Id = 2,
                StudentId = 1,
                ClassId = 7,
                Number = 80.4
            };
            bool res = await teacherServiceRepository.UpdateScore(score);
            Assert.True(res, "Score is updated successfully");
        }
        [Fact]
        public async void GetStudentsOfClass_ShouldReturnStudents_WhenCalled()
        {
            TeacherServiceRepository teacherServiceRepository = new TeacherServiceRepository();
            List<Student> students = await teacherServiceRepository.GetStudentsOfClass(7);
            Assert.Equal(1, students.Count);
        }
    }
}
