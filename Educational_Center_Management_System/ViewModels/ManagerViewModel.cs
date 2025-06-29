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
        public ICommand ShowAdd { get; set; }
        public ICommand ShowAll { get; set; }
        public ICommand ShowSearch { get; set; }
        public ICommand ShowUpdateStudent { get; set; }
        public ICommand ShowUpdateTeacher { get; set; }

        public ManagerViewModel(Manager manager)
        {
            Manager = manager;
            CurrentViewModel = new ManagerDashboardViewModel(Manager);
            ShowDashboard = new RelayCommand(ExecuteShowDashboard);
            ShowAdd = new RelayCommand(ExecuteShowAdd);
            ShowAll = new RelayCommand(ExecuteShowAll);
            ShowSearch = new RelayCommand(ExecuteShowSearch);
            ShowUpdateStudent = new RelayCommand(ExecuteShowUpdateStudent);
            ShowUpdateTeacher = new RelayCommand(ExecuteShowUpdateTeacher);
        }
        private void ExecuteShowDashboard(object? parameter)
        {
            CurrentViewModel = new ManagerDashboardViewModel(Manager);
        }
        private void ExecuteShowAdd(object? parameter)
        {
            CurrentViewModel = new ManagerAddViewModel();
        }
        private void ExecuteShowAll(object? parameter)
        {
            CurrentViewModel = new ManagerViewAllViewModel();
        }
        private void ExecuteShowSearch(object? parameter)
        {
            CurrentViewModel = new ManagerSearchViewModel();
        }
        private void ExecuteShowUpdateStudent(object? parameter)
        {
            CurrentViewModel = new ManagerUpdateStudentViewModel();
        }
        private void ExecuteShowUpdateTeacher(object? parameter)
        {
            CurrentViewModel = new ManagerUpdateTeacherViewModel();
        }
    }
}
