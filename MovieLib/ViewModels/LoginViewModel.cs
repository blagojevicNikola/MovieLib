using MovieLib.Commands;
using MovieLib.Models;
using MovieLib.Repositories.Impl;
using MovieLib.Repositories.Interfaces;
using MovieLib.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MovieLib
{
    public class LoginViewModel:BaseViewModel
    {
        private string _error = "";
        private string? _username;
        private string? _password;
        private User? _user;
        private Admin? _admin;
        public string? Username { get { return _username; } set { _username = value; NotifyPropertyChanged("Username"); } }    
        public string? Password { get { return _password; } set { _password = value; NotifyPropertyChanged("Password"); } }
        public string Error { get { return _error; } set { _error = value; NotifyPropertyChanged("Error"); } }
        public ICommand ToUserViewCommand { get; set; }
        public ICommand ToAdminViewCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
       
        public LoginViewModel(NavigationStore navigationStore)
        {
            RegisterCommand = new NavigateCommand<RegisterViewModel>(navigationStore, () => new RegisterViewModel(navigationStore));
            ToAdminViewCommand = new NavigateCommand<AdminMainViewModel>(navigationStore, () => {
                preset(_admin);
                NavigationStore navigationStore1 = new();
                navigationStore1.CurrentViewModel = new MoviesAdminViewModel(navigationStore1, _admin);
                return new AdminMainViewModel(navigationStore, navigationStore1, _admin);
            });
            ToUserViewCommand = new NavigateCommand<UserMainViewModel>(navigationStore, () =>
            {
                preset(_user);
                NavigationStore navigationStore2 = new();
                navigationStore2.CurrentViewModel = new MoviesUserViewModel(navigationStore2, _user);
                return new UserMainViewModel(navigationStore, navigationStore2, _user);
            });
            LoginCommand = new AsyncRelayCommand(loggingIn, (ex) => { MessageBox.Show("Error while logging in!"); });
        }


        private async Task loggingIn()
        {
            IAuthenticationRepository rep = new AuthenticationRepository();
            
            Admin? admin = await rep.LoginAdmin(Username, Password);
            if (admin is null)
            {
                User? user = await rep.LoginUser(Username, Password);
                if (user is not null)
                {
                    _user = user;
                    ToUserViewCommand.Execute(null);
                }
            }
            else
            {
                _admin = admin;
                ToAdminViewCommand.Execute(null);
            }
            
        }

        private bool canLogIn()
        {
            if(string.IsNullOrEmpty(Username))
            {
                Error = "Username/password field is empty!";
                return false;
            }
            else
            {
                Error = "";
                return true;
            }
        }

        private void preset(Person person)
        {
            Application.Current.Resources.MergedDictionaries[0].Clear();
            Application.Current.Resources.MergedDictionaries[1].Clear();
            //Application.Current.Resources.MergedDictionaries[1].Clear();
            ResourceDictionary darkRes = new ResourceDictionary();
            darkRes.Source = new Uri("/Resources/DarkTheme.xaml", UriKind.Relative);
            ResourceDictionary lightRes = new ResourceDictionary();
            lightRes.Source = new Uri("/Resources/LightTheme.xaml", UriKind.Relative);
            ResourceDictionary customRes = new ResourceDictionary();
            customRes.Source = new Uri("/Resources/CustomTheme.xaml", UriKind.Relative);
            ResourceDictionary serbianRes = new ResourceDictionary();
            serbianRes.Source = new Uri("/Resources/SerbianLanguage.xaml", UriKind.Relative);
            ResourceDictionary englishRes = new ResourceDictionary();
            englishRes.Source = new Uri("/Resources/EnglishLanguage.xaml", UriKind.Relative);
            if (person.Language!="srb")
            {
                Application.Current.Resources.MergedDictionaries[0].MergedDictionaries.Add(serbianRes);
                Application.Current.Resources.MergedDictionaries[0].MergedDictionaries.Add(englishRes);
            }
            else
            {
                Application.Current.Resources.MergedDictionaries[0].MergedDictionaries.Add(englishRes);
                Application.Current.Resources.MergedDictionaries[0].MergedDictionaries.Add(serbianRes);
            }
            switch (person.Theme)
            {
                case "Dark":
                    {
                        Application.Current.Resources.MergedDictionaries[1].MergedDictionaries.Add(customRes);
                        Application.Current.Resources.MergedDictionaries[1].MergedDictionaries.Add(lightRes);
                        Application.Current.Resources.MergedDictionaries[1].MergedDictionaries.Add(darkRes);
                        break;
                    }
                case "Light":
                    {
                        Application.Current.Resources.MergedDictionaries[1].MergedDictionaries.Add(customRes);
                        Application.Current.Resources.MergedDictionaries[1].MergedDictionaries.Add(darkRes);
                        Application.Current.Resources.MergedDictionaries[1].MergedDictionaries.Add(lightRes);
                        break;
                    }
                case "Custom":
                    {
                        Application.Current.Resources.MergedDictionaries[1].MergedDictionaries.Add(darkRes);
                        Application.Current.Resources.MergedDictionaries[1].MergedDictionaries.Add(lightRes);
                        Application.Current.Resources.MergedDictionaries[1].MergedDictionaries.Add(customRes);
                        break;
                    }
                default:
                    {
                        Application.Current.Resources.MergedDictionaries[1].MergedDictionaries.Add(customRes);
                        Application.Current.Resources.MergedDictionaries[1].MergedDictionaries.Add(lightRes);
                        Application.Current.Resources.MergedDictionaries[1].MergedDictionaries.Add(darkRes);
                        break;
                    }
            }

        }
    }
}
