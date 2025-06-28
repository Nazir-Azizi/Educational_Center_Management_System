using Educational_Center_Management_System.Helpers;
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
using System.Windows.Data;
using System.Windows.Input;

namespace Educational_Center_Management_System.ViewModels
{
    public class ManagerAllStudentsViewModel
    {
        public String IdDelete { get; set; }
        private IManagerService _managerService;
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();
        public ManagerAllStudentsViewModel()
        {
            _managerService = new ManagerService();
            _ = getStudents();
        }
        private async Task getStudents()
        {
            List<Student?> list = await _managerService.GetAllStudents();
            foreach(Student? student in list)
            {
                if (student != null)
                    Students.Add(student);
            }
        }
    }
}
