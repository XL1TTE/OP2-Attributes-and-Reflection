using OP2.Core;
using OP2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OP2.MVVM.ViewModel
{
    class HomeViewModel: Core.ViewModel
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


        public HomeViewModel(INavigationService navigationService)
        {
            
        }
    }
}
