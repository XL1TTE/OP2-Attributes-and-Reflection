
using OP2.Core;
using OP2.MVVM.Model;
using OP2.MVVM.View;
using OP2.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace OP2.MVVM.ViewModel
{
    public class ConsoleViewModel : Core.ViewModel
    {
        private Dictionary<string, Dictionary<string, RelayCommand>> ConsoleCommands;
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
        private string _text;
        public string Text
        {
            get => _text;

            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        private bool _isFocus;
        public bool IsFocus
        {
            get => _isFocus;

            set
            {
                _isFocus = value;
                OnPropertyChanged();
            }
        }
        private string _consoleLog;
        public string ConsoleLog
        {
            get => _consoleLog;

            set
            {
                _consoleLog = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand NavigateToHome { get; set; }
        public RelayCommand NavigateToConsole { get; set; }
        public RelayCommand NavigateToSettings { get; set; }
        public RelayCommand EnterCommand { get; set; }
        public RelayCommand ClearConsoleLog { get; set; }
        public RelayCommand StartTester { get; set; }
        public RelayCommand GetConsoleGuide {  get; set; }
        public ConsoleViewModel(INavigationService navigationService, Tester tester)
        {
            
            ConsoleCommands = new Dictionary<string, Dictionary<string, RelayCommand>>()
            {
                {"Settings", new Dictionary<string, RelayCommand>(){
                    {"Execute", new RelayCommand(o => { Navigation.NavigateTo<SettingsViewModel>(); }, o => true)},
                    {"GetInfo", new RelayCommand(o => { ConsoleLog += "Settings - Switch to Settings page.\n"; }, o => true)}
                } },

                {"Exit", new Dictionary<string, RelayCommand>(){
                    {"Execute", new RelayCommand(o => {Application.Current.Shutdown(); }, o => true)},
                    {"GetInfo", new RelayCommand(o => { ConsoleLog += "Exit - Close the application.\n";  }, o => true)}
                } },

                {"Clear", new Dictionary<string, RelayCommand>(){
                    {"Execute", new RelayCommand(o => { ConsoleLog = String.Empty; }, o => true)},
                    {"GetInfo", new RelayCommand(o => { ConsoleLog += "Clear - Clear console's logs.\n";  }, o => true)}
                } },
                {"StartTester", new Dictionary<string, RelayCommand>(){
                    {"Execute", new RelayCommand(o => { tester.TestWith(ObjectsList._ControlTest); ConsoleLog += tester.Log; tester.Log = String.Empty; }, o => true)},
                    {"GetInfo", new RelayCommand(o => { ConsoleLog += "StartTester - Start OP2.\n"; ; }, o => true)}
                } },
                {"INFO", new Dictionary<string, RelayCommand>(){
                    {"Execute", new RelayCommand(o => { ConsoleGuide(); }, o => true)},
                    {"GetInfo", new RelayCommand(o => { ConsoleLog += "INFO - Get info about console commands.\n"; ; }, o => true)}
                } },



            };
            ConsoleGuide();
            Navigation = navigationService;
            NavigateToHome = ConsoleCommands["Exit"]["Execute"];
            NavigateToSettings = ConsoleCommands["Settings"]["Execute"];
            ClearConsoleLog = ConsoleCommands["Clear"]["Execute"];
            StartTester = ConsoleCommands["StartTester"]["Execute"];
            GetConsoleGuide = ConsoleCommands["INFO"]["Execute"];
            EnterCommand = new RelayCommand(o =>
            {
                KeyEventArgs args = o as KeyEventArgs;
                if(args.Key == Key.Enter)
                {
                    ConsoleLog += $"{Text}\n";
                    try
                    {
                        ConsoleCommands[Text]["Execute"].Execute(null);
                    }
                    catch
                    {
                        ConsoleLog += $"Command ({Text}) is not defined!\n";
                    }
                    Text = String.Empty;
                }
            }
            , o => true);
            
        }
        private void ConsoleGuide()
        {
            ConsoleLog += "Available console commands \n";
            foreach (var pair in ConsoleCommands)
            {
                ConsoleCommands[$"{pair.Key}"]["GetInfo"].Execute(null);
            }
        }

    }
}
