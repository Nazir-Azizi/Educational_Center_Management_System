using Educational_Center_Management_System.Models;
using Educational_Center_Management_System.Services;
using Educational_Center_Management_System.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Educational_Center_Management_System.ViewModels
{
    public class ManagerAllTeachersViewModel
    {
        private IManagerService _managerService;
        public ObservableCollection<Teacher> Teachers { get; set; } = new ObservableCollection<Teacher>();
        public ManagerAllTeachersViewModel()
        {
            _managerService = new ManagerService();
            _ = getTeachers();
        }
        private async Task getTeachers()
        {
            List<Teacher?> list = await _managerService.GetAllTeachers();
            foreach (Teacher? teacher in list)
            {
                if (teacher != null)
                    Teachers.Add(teacher);
            }
        }
    }
}
