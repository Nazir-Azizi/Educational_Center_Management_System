using Educational_Center_Management_System.Enums;
using Educational_Center_Management_System.Services.Interfaces;
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
            _navigationService = navigationService;
            LogInCommnad = new RelayCommand(ExecuteLogIn);
        }
        private async void ExecuteLogIn(object? parameter)
        {

            if (!IdTextBox.IsNullOrEmpty() && !PasswordBox.IsNullOrEmpty())
            {
                if(SelectedUserType == UserType.Student)
                {
                    StudentManagerService studentManagerService = new StudentManagerService();
                    Student student = await studentManagerService.GetStudent(int.Parse(IdTextBox));
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
                    Teacher teacher = new Teacher
                    {
                        Id = 1,
                        Name = "Nazir",
                        LastName = "Azizi",
                        Fathername = "Mohammad Aziz",
                        BirthDate = new DateOnly(2003, 1, 19),
                        Photo = null,
                        PhoneNumber = "0783360601",
                        JoinDate = new DateOnly(2010, 9, 1),
                        LeaveDate = new DateOnly(2024, 9, 16),
                        State = 1,
                        Password = "iamteacher123"
                    };
                    _navigationService.NavigateTo(new TeacherViewModel(teacher));
                }
            }
            else
            {
                MessageBox.Show("Empty Input");
            }
        }
    }
}
