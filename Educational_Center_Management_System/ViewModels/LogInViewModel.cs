using Educational_Center_Management_System.Enums;
using Educational_Center_Management_System.Services.Interfaces;
using System.Windows.Input;
using Educational_Center_Management_System.Helpers;

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
            // when button clicked
            _navigationService.NavigateTo(new StudentDashboardViewModel());
        }
    }
}
