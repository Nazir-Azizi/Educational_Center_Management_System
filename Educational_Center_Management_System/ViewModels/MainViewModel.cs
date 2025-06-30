
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Educational_Center_Management_System.Helpers;
using Educational_Center_Management_System.Services;

namespace Educational_Center_Management_System.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
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
        NavigationService _navigationService;
        public ICommand GoToHomePageCommand { get; set; }
        public MainViewModel()
        {
            GoToHomePageCommand = new RelayCommand(ExecuteGoToHomePageCommand);
            _navigationService = new NavigationService(this);
            CurrentViewModel = new LogInViewModel(_navigationService);
        }
        private void ExecuteGoToHomePageCommand (object? parameter)
        {
            CurrentViewModel = new LogInViewModel(_navigationService);
        }
    }
}
