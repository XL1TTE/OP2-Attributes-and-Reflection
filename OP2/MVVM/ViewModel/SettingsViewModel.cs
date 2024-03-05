using OP2.Core;
using OP2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP2.MVVM.ViewModel
{
    class SettingsViewModel : Core.ViewModel
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
        private string _windowLabel;
        public string WindowLabel
        {
            get => _windowLabel;

            set
            {
                _windowLabel = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToConsole { get; set; }
        public SettingsViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            NavigateToConsole = new RelayCommand(o => { Navigation.NavigateTo<ConsoleViewModel>(); }, o => true);
        }
    }
}
