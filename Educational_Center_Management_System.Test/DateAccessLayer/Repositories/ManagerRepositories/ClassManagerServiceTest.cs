using Educational_Center_Management_System.DataAccessLayer.Repositories.ManagerRepositories;
using Educational_Center_Management_System.Models;
using Xunit;


namespace Educational_Center_Management_System.Test.DateAccessLayer.Repositories.ManagerRepositories
{
    public class ClassManagerServiceTest
    {
        [Fact]
        public async void CreateClass_ShouldReturnTrue_WhenClassIsCreatedSuccessfully()
        {
            ClassManagerService classManagerService = new ClassManagerService();
            var newClass = new Class
            {
                State = 1,
                Teacher = 1,
                Semester = "B",
                Name = "Math 101",
                Time = new TimeSpan(8,0,0),
                Date = new DateOnly(2025, 9, 1)
            };
            bool res = await classManagerService.CreateClass(newClass);
            Assert.True(res, "Class should be created successfully.");
        }
        [Fact]
        public async void DeleteClass_ShouldReturnTrue_WhenClassIsDeletedSuccessfully()
        {
            ClassManagerService classManagerService = new ClassManagerService();
            int classIdToDelete = 6; // Assuming this class ID exists in the database
            bool res = await classManagerService.DeleteClass(classIdToDelete);
            Assert.True(res, "Class should be deleted successfully.");
        }
        [Fact]
        public async void UpdateClass_ShouldReturnTrue_WhenClassIsUpdatedSuccessfully()
        {
            ClassManagerService classManagerService = new ClassManagerService();
            var updatedClass = new Class
            {
                State = 1,
                Teacher = 1,
                Semester = "C",
                Name = "Advance",
                Time = new TimeSpan(10,0,0),
                Date = new DateOnly(2025, 9, 1)
            };
            bool res = await classManagerService.UpdateClass(updatedClass);
            Assert.True(res, "Class should be updated successfully.");
        }
    }
}
