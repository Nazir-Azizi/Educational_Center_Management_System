using Educational_Center_Management_System.Models;
using Educational_Center_Management_System.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational_Center_Management_System.ViewModels
{
    public class TeacherDashboardViewModel
    {
        
        public Teacher Teacher { get; set; }

        public TeacherDashboardViewModel(Teacher teacher)
        {
            Teacher = teacher;
        }
        
    }
}
