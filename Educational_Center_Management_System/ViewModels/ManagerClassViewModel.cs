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
    public class ManagerClassViewModel : BaseViewModel
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
        public ICommand ShowClassOptions { get; set; }
        public ManagerClassViewModel()
        {
            ShowClassOptions = new RelayCommand(ExecuteShowClassOptions);
        }
        private void ExecuteShowClassOptions(object? parameter)
        {
            if (SelectedUserType == UserType.Student)
            {
                CurrentViewModel = new ManagerCreateClassViewModel();
            }
            else
            {
                CurrentViewModel = new ManagerUpdateClassViewModel();
            }
        }
    }
}
