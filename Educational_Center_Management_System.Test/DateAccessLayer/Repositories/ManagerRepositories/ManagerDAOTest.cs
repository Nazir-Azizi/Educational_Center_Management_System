using Educational_Center_Management_System.DataAccessLayer.Repositories.ManagerRepositories;
using Educational_Center_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational_Center_Management_System.Test.DateAccessLayer.Repositories.ManagerRepositories
{
    public class ManagerDAOTest
    {
        [Fact]
        public async void GetManager_ShouldReturnManager_WhenCalled()
        {
            ManagerDAO managerDAO = new ManagerDAO();
            Manager? manager = await managerDAO.GetManager();
            Assert.NotNull(manager);
            Assert.Equal(1, manager.Id);
        }
        [Fact]
        public async void UpdataManager_ShouldUpdateManager_WhenCalled()
        {
            ManagerDAO managerDAO = new ManagerDAO();
            Manager manager = new Manager()
            {
                Name = "Aziz",
                LastName = "Alizada",
                Photo = null,
                Password = "abc"
            };
            bool res = await managerDAO.UpdataManager(manager);
            Assert.True(res, "Student Updated Successfully");
        }
    }
}
