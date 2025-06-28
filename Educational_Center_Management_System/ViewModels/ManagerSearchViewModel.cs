using Educational_Center_Management_System.Enums;
using Educational_Center_Management_System.Helpers;
using Educational_Center_Management_System.Models;
using Educational_Center_Management_System.Services;
using Educational_Center_Management_System.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Educational_Center_Management_System.ViewModels
{
    public class ManagerSearchViewModel : BaseViewModel
    {
        IManagerService _managerService;
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

        private UserType _selectedUserType = UserType.Student;
        public UserType SelectedUserType
        {
            get { return _selectedUserType; }
            set
            {
                _selectedUserType = value;
                onPropertyChanged();
            }
        }
        public ICommand SearchCommand { get; set; }
        public string IdText { get; set; }
        public ManagerSearchViewModel()
        {
            _managerService = new ManagerService();
            SearchCommand = new RelayCommand(ExecuteSearchCommand);
        }
        private async void ExecuteSearchCommand(object? parameter)
        {
            if (int.TryParse(IdText, out int value))
            {
                if (SelectedUserType == UserType.Student)
                {
                    Student? student = await _managerService.GetStudent(value);           
                    if (student == null)
                    {
                        MessageBox.Show("No such id exist");
                    }
                    else
                    {
                        CurrentViewModel = new StudentDashboardViewModel(student);
                    }
                }
                else
                {
                    Teacher? teahcer = await _managerService.GetTeacher(value);
                    if (teahcer == null)
                    {
                        MessageBox.Show("No such id exist");
                    }
                    else
                    {
                        CurrentViewModel = new TeacherDashboardViewModel(teahcer);
                    }
                }
            }
            else
            {
                MessageBox.Show("ERROR! Invalid Input");
            }
        }
    }
}
