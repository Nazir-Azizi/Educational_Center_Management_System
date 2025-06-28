using Educational_Center_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educational_Center_Management_System.ViewModels
{
    public class ManagerViewModel : BaseViewModel
    {
        private object _currentTeacherViewModel;
        public object CurrentViewModel
        {
            get => _currentTeacherViewModel;
            set
            {
                _currentTeacherViewModel = value;
                onPropertyChanged();
            }
        }

        public ManagerViewModel(Manager manager)
        {
            CurrentViewModel = new ManagerAddStudentViewModel();
        }
    }
}
