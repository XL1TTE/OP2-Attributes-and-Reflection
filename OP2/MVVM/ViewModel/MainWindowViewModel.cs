
using OP2.Core;
using OP2.MVVM.View;
using OP2.Services;
using System.Security.Policy;
using System.Windows.Media.Animation;

namespace OP2.MVVM.ViewModel
{
    class MainWindowViewModel: Core.ViewModel
    {
        private INavigationService _navigation;
        public INavigationService Navigation
        {
            get => _navigation;

            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            Navigation.NavigateTo<ConsoleViewModel>();
            
        }
    }
}
