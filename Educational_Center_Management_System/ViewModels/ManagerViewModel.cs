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
        public ICommand ShowUpdate { get; set; }
        public ICommand ShowClass { get; set; }
        public ICommand ShowSettings { get; set; }
        public ManagerViewModel(Manager manager)
        {
            Manager = manager;
            CurrentViewModel = new ManagerDashboardViewModel(Manager);
            ShowDashboard = new RelayCommand(ExecuteShowDashboard);
            ShowAdd = new RelayCommand(ExecuteShowAdd);
            ShowAll = new RelayCommand(ExecuteShowAll);
            ShowSearch = new RelayCommand(ExecuteShowSearch);
            ShowUpdate = new RelayCommand(ExecuteShowUpdate);
            ShowClass = new RelayCommand(ExecuteShowClass);
            ShowSettings = new RelayCommand(ExecuteShowSettings);
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
        private void ExecuteShowUpdate(object? parameter)
        {
            CurrentViewModel = new ManagerUpdateViewModel();
        }
        private void ExecuteShowClass(object? parameter)
        {
            CurrentViewModel = new ManagerClassViewModel();
        }
        private void ExecuteShowSettings(object? parameter)
        {
            CurrentViewModel = new ManagerSettingViewModel();
        }
    }
}
