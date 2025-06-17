
using System.ComponentModel;
using System.Windows;
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
        public MainViewModel()
        {
            _navigationService = new NavigationService(this);
            CurrentViewModel = new LogInViewModel(_navigationService);
        }
    }
}
