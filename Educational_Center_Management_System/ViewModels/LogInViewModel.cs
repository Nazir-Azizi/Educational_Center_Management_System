using Educational_Center_Management_System.Enums;
using Educational_Center_Management_System.Services.Interfaces;
using Educational_Center_Management_System.Services;
using System.Windows.Input;
using Educational_Center_Management_System.Helpers;
using Educational_Center_Management_System.Models;
using Microsoft.IdentityModel.Tokens;
using System.Windows;
using Educational_Center_Management_System.DataAccessLayer.Repositories.ManagerRepositories;

namespace Educational_Center_Management_System.ViewModels
{
    internal class LogInViewModel : BaseViewModel
    {
        IManagerService _managerService;
        private string _idTextBox;

        public string IdTextBox
        {
            get { return _idTextBox; }
            set { _idTextBox = value; }
        }
        private string _passwordbox;

        public string PasswordBox
        {
            get { return _passwordbox; }
            set { _passwordbox = value; }
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
        public ICommand LogInCommnad { get; }


		INavigationService _navigationService;

        public LogInViewModel(INavigationService navigationService)
        {
            _managerService = new ManagerService();
            _navigationService = navigationService;
            LogInCommnad = new RelayCommand(ExecuteLogIn);
        }
        private async void ExecuteLogIn(object? parameter)
        {

            if (!IdTextBox.IsNullOrEmpty() && !PasswordBox.IsNullOrEmpty())
            {
                if(SelectedUserType == UserType.Student)
                {
                    Student? student = await _managerService.GetStudent(int.Parse(IdTextBox));
                    if (student == null || student.Password != PasswordBox)
                    {
                        MessageBox.Show("Wrong Id or password");
                    }
                    else
                    {
                        _navigationService.NavigateTo(new StudentDashboardViewModel(student));
                    }
                }
                else if (SelectedUserType == UserType.Teacher)
                {
                    Teacher? teacher = await _managerService.GetTeacher(int.Parse(IdTextBox));
                    if (teacher == null || teacher.Password != PasswordBox)
                    {
                        MessageBox.Show("Wrong Id or password");
                    }
                    else
                    {
                        _navigationService.NavigateTo(new TeacherViewModel(teacher));
                    }
                }
                else
                {
                    Manager? manager = await _managerService.GetManager();
                    if (manager == null || manager.Password != PasswordBox)
                    {
                        MessageBox.Show("Wrong Id or password");
                    }
                    else
                    {
                        _navigationService.NavigateTo(new ManagerViewModel(manager));
                    }
                }
            }
            else
            {
                MessageBox.Show("Empty Input");
            }
        }
    }
}
