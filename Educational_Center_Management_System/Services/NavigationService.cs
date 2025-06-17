using Educational_Center_Management_System.Services.Interfaces;
using Educational_Center_Management_System.ViewModels;

namespace Educational_Center_Management_System.Services
{
    public class NavigationService : INavigationService
    {
        MainViewModel _mainViewModel;

        public NavigationService(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
        // not done yet
        public void NavigateTo(object viewModel)
        {
            _mainViewModel.CurrentViewModel = viewModel;
        }
    }
}
