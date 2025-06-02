using Educational_Center_Management_System.DataAccessLayer.Repositories.ManagerRepositories;
using Educational_Center_Management_System.Models;
using System.Diagnostics;
using System.Windows.Documents;
using Xunit;

namespace Educational_Center_Management_System.Test.DateAccessLayer.Repositories.ManagerRepositories
{
    public class StudentManagerServiceTest
    {
        [Fact]
        public async void AddStudent_ShouldReturnTrue_WhenStudentIsAddedSuccessfully()
        {
            StudentManagerService studentManagerService = new StudentManagerService();
            Student student = new Student
            {
                Name = "Mahid",
                LastName = "Azizi",
                Fathername = "Mohammad Aziz",
                BirthDate = new DateOnly(2005, 12, 19), 
                Photo = null, // Assuming photo is not required for this test
                PhoneNumber = "0783360601",
                JoinDate = new DateOnly(2030, 9, 1),
                State = 1,
                Password = "faty"
            };
            bool res = await studentManagerService.AddStudent(student);
            Assert.True(res, "Student added successfuly");
        }
        [Fact]
        public async void DeleteStudent_ShouldReturnTrue_WhenStudentIsDeletedSuccessfully()
        {
            StudentManagerService studentManagerService = new StudentManagerService();
            int studentId = 4;
            bool res = await studentManagerService.DeleteStudent(studentId);
            Assert.True(res, "Student deleted successfuly");
        }
        [Fact]
        public async void UpdateStudent_ShouldReturnTrue_WhenStudentIsUpdatedSuccessfully()
        {
            StudentManagerService studentManagerService = new StudentManagerService();
            Student student = new Student
            {
                Id = 3,
                Name = "Mahid",
                LastName = "Azizi",
                Fathername = "Mohammad Aziz",
                BirthDate = new DateOnly(2005, 12, 19),
                Photo = null, // Assuming photo is not required for this test
                PhoneNumber = "0783360601",
                JoinDate = new DateOnly(2030, 9, 1),
                State = 1,
                Password = "faty"
            };
            bool res = await studentManagerService.UpdateStudent(student);
            Assert.True(res, "Student updated successfuly");
        }
        [Fact]
        public async void GetStudent_ShouldReturnStudent_WhenStudentExists()
        {
            StudentManagerService studentManagerService = new StudentManagerService();
            int studentId = 1;
            Student? student = await studentManagerService.GetStudent(studentId);
            Assert.NotNull(student);
            Assert.Equal(studentId, student.Id);
        }
        [Fact]
        public async void GetAllStudents_ShouldRetrunAllStudents_WhenCalled()
        {
            StudentManagerService studentManagerService = new StudentManagerService();
            List<Student?> students = await studentManagerService.GetAllStudents();
            Assert.Equal(2 ,students.Count);
        }
    }
}
