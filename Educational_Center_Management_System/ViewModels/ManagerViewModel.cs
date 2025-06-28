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
        Manager Manager { get; set; }
        public ICommand ShowDashboard { get; set; }
        public ICommand ShowAddStudent { get; set; }
        public ICommand ShowAllStudents { get; set; }
        public ICommand ShowSearchStudents { get; set; } // to be implemented

        public ManagerViewModel(Manager manager)
        {
            Manager = manager;
            CurrentViewModel = new ManagerDashboardViewModel(Manager);
            ShowDashboard = new RelayCommand(ExecuteShowDashboard);
            ShowAddStudent = new RelayCommand(ExecuteShowAddStudent);
            ShowAllStudents = new RelayCommand(ExecuteShowAllStudents);
        }
        private void ExecuteShowDashboard(object? parameter)
        {
            CurrentViewModel = new ManagerDashboardViewModel(Manager);
        }
        private void ExecuteShowAddStudent(object? parameter)
        {
            CurrentViewModel = new ManagerAddStudentViewModel();
        }
        private void ExecuteShowAllStudents(object? parameter)
        {
            CurrentViewModel = new ManagerAllStudentsViewModel();
        }


    }
}
