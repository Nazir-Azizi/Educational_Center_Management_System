
using Educational_Center_Management_System.Models;

namespace Educational_Center_Management_System.ViewModels
{
    public class ManagerDashboardViewModel
    {
		public Manager Manager { get; set; }
        public ManagerDashboardViewModel(Manager manager)
        {
            Manager = manager;
        }

    }
}
