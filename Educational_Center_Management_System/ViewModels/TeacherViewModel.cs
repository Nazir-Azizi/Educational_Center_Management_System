using Educational_Center_Management_System.Helpers;
using Educational_Center_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Educational_Center_Management_System.ViewModels
{
    public class TeacherViewModel : BaseViewModel
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

        public ICommand ShowClassList { get; }
        public ICommand ShowDashboard { get; }
        private Teacher _teacher;

        public TeacherViewModel(Teacher teacher)
        {
            _teacher = teacher;
            _currentTeacherViewModel = new TeacherDashboardViewModel(teacher);
            ShowClassList = new RelayCommand(ExecuteShowSeeClasses);
            ShowDashboard = new RelayCommand(ExecuteShowDashboard);
        }
        private void ExecuteShowSeeClasses(object? parameter)
        {
            CurrentViewModel = new TeacherCLassListViewModel(_teacher);
        }
        private void ExecuteShowDashboard(object? parameter)
        {
            CurrentViewModel = new TeacherDashboardViewModel(_teacher);
        }
    }
}
