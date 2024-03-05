using OP2.Core;
using OP2.MVVM.View;
using OP2.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace OP2.Services
{

    public interface INavigationService
    {
        ViewModel CurrentViewModel { get; }

        void NavigateTo<T>() where T : ViewModel;
    }

    public class NavigationService : ObservableObject, INavigationService
    {
        private ViewModel _currentViewModel;
        private Func<Type, ViewModel> _viewModelFactory;
        public ViewModel CurrentViewModel
        {
            get => _currentViewModel;

            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public NavigationService(Func<Type, ViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModel
        {
            ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentViewModel = viewModel;
        }
    }
}
