using Educational_Center_Management_System.Enums;
using Educational_Center_Management_System.Services.Interfaces;
using System.Windows.Input;
using Educational_Center_Management_System.Helpers;
using Educational_Center_Management_System.Models;

namespace Educational_Center_Management_System.ViewModels
{
    internal class LogInViewModel : BaseViewModel
    {


		private UserType _selectedUserType;
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
        private void ExecuteLogIn(object? parameter)
        {
            Student student = new Student
            {
                Id = 1,
                Name = "Nazir",
                Fathername = "Mohammad Aziz",
                LastName = "Azizi",
                BirthDate = new DateOnly(2003, 1, 19),
                Photo = null,
                PhoneNumber = "0783360601",
                JoinDate = new DateOnly(2024, 4, 12),
                State = 1,
                Password = "Hooooo"
            };
            // when button clicked
            _navigationService.NavigateTo(new StudentDashboardViewModel(student));
        }
    }
}
