
using Microsoft.Extensions.DependencyInjection;
using OP2.Core;
using OP2.MVVM.View;
using OP2.MVVM.ViewModel;
using OP2.Services;
using System;
using System.Windows;
using OP2.MVVM.Model;

namespace OP2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();

            // Services
            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainWindowViewModel>()
            }) ; 

            // ViewModelServices
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddSingleton<ConsoleViewModel>();

            // Tester
            services.AddSingleton<Tester>(provider => new Tester(ObjectsList._ToTest));

            //NavigationService
            services.AddSingleton<INavigationService, NavigationService>();

            //Fabric
            services.AddSingleton<Func<Type, ViewModel>>(provider => ViewModelType => (ViewModel)provider.GetRequiredService(ViewModelType));

            services.AddSingleton<MainWindowViewModel>();


            _serviceProvider = services.BuildServiceProvider();
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            var MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
