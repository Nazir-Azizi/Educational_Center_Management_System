using Educational_Center_Management_System.DataAccessLayer.Repositories.ManagerRepositories;
using Educational_Center_Management_System.Models;
using Xunit;

namespace Educational_Center_Management_System.Test.DateAccessLayer.Repositories.ManagerRepositories
{
    public class TeacherManagerServiceTest
    {
        [Fact]
        public async void AddTeacher_ShouldReturnTrue_WhenTeacherIsAddedSuccessfully()
        {
            TeacherManagerService teacherManagerService = new TeacherManagerService();
            Teacher teacher = new Teacher
            {
                Name = "Nazir",
                LastName = "Azizi",
                Fathername = "Mohammad Aziz",
                BirthDate = new DateOnly(2003, 1, 19),
                Photo = null,
                PhoneNumber = "0783360601",
                JoinDate = new DateOnly(2010, 9, 1),
                LeaveDate = new DateOnly(2024, 9, 16),
                State = 1,
                Password = "iamteacher123"
            };
            bool res = await teacherManagerService.AddTeacher(teacher);
            Assert.True(res, "Teacher Added Successfully");
        }
        [Fact]
        public async void DeleteTeacher_ShouldReturnTrue_WhenTeacherIsDeletedSuccessfully()
        {
            TeacherManagerService teacherManagerService = new TeacherManagerService();
            int teacherId = 2;
            bool res = await teacherManagerService.DeleteTeacher(teacherId);
            Assert.True(res, "Teacher deleted successfully");
        }
        [Fact]
        public async void UpdateTeacjer_ShouldReturnTrue_WhenTeacherIsUpdatedSuccessfully()
        {
            TeacherManagerService teacherManagerService = new TeacherManagerService();
            Teacher teacher = new Teacher
            {
                Id = 1,
                Name = "Nazir",
                LastName = "Azizi",
                Fathername = "Mohammad Aziz",
                BirthDate = new DateOnly(2003, 1, 19),
                Photo = null,
                PhoneNumber = "0783360601",
                JoinDate = new DateOnly(2010, 9, 1),
                LeaveDate = new DateOnly(2024, 9, 16),
                State = 1,
                Password = "iamteacher123"
            };

            bool res = await teacherManagerService.UpdateTeacher(teacher);
            Assert.True(res, "Teacher updated successfully");
        }
        [Fact]
        public async void GetTeacher_ShouldReturnTeacher_WhenTeacherExists()
        {
            TeacherManagerService teacherManagerService = new TeacherManagerService();
            int teacherId = 1;
            Teacher? teacher = await teacherManagerService.GetTeacher(teacherId);
            Assert.NotNull(teacher);
            Assert.Equal(teacherId, teacher.Id);
        }
        [Fact]
        public async void GetAllTeachers_ShouldReturnAllTeachers_WhenCalled()
        {
            TeacherManagerService teacherManagerService = new TeacherManagerService();
            List<Teacher?> teachers = await teacherManagerService.GetAllTeachers();
            Assert.Equal(1, teachers.Count);
        }
    }
}
