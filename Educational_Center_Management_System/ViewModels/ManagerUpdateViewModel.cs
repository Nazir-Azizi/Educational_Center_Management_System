using Educational_Center_Management_System.Enums;
using Educational_Center_Management_System.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Educational_Center_Management_System.ViewModels
{
    public class ManagerUpdateViewModel : BaseViewModel
    {
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
        private object _currentViewModel;
        public object CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                onPropertyChanged();
            }
        }
        public ICommand ShowUpdatePage { get; set; }
        public ManagerUpdateViewModel()
        {
            ShowUpdatePage = new RelayCommand(ExecuteShowUpdatePage);
        }
        private void ExecuteShowUpdatePage(object? parameter)
        {
            if (SelectedUserType == UserType.Student)
            {
                CurrentViewModel = new ManagerUpdateStudentViewModel();
            }
            else
            {
                CurrentViewModel = new ManagerUpdateTeacherViewModel();
            }
        }
    }
}
