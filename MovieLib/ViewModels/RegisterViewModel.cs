using MovieLib.Commands;
using MovieLib.Models;
using MovieLib.Repositories.Impl;
using MovieLib.Repositories.Interfaces;
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
    public class RegisterViewModel : BaseViewModel
    {
        private NavigationStore _navigationStore;
        private string _username;
        private string _password;
        private string _name;
        private string _surname;
        public string Username { get { return _username; } set { _username = value; NotifyPropertyChanged("Username"); } }
        public string Password { get { return _password; } set { _password = value; NotifyPropertyChanged("Password"); } }
        public string Name { get { return _name; } set { _name = value; NotifyPropertyChanged("Name"); } }
        public string Surname { get { return _surname; } set { _surname = value; NotifyPropertyChanged("Surname"); } }

        public ICommand BackToLoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public RegisterViewModel(NavigationStore navigationStore)
        {
            Username = "";
            Password = "";
            Name = "";
            Surname = "";
            _navigationStore = navigationStore;
            BackToLoginCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
            RegisterCommand = new RelyCommand(register);
        }

        public void register()
        {
            IAuthenticationRepository authRep = new AuthenticationRepository();
            User? user = null;
            try
            {
                user = authRep.RegisterUser(new User(null, Name, Surname, Username, false, "", ""), Password);
                if (user == null) { return; }
                ICommand ToUserViewCommand = new NavigateCommand<UserMainViewModel>(_navigationStore, () =>
                {
                    NavigationStore navigationStore2 = new();
                    navigationStore2.CurrentViewModel = new MoviesUserViewModel(navigationStore2, user);
                    return new UserMainViewModel(_navigationStore, navigationStore2, user);
                });
                ToUserViewCommand.Execute(null);
            }catch(MySqlException)
            {
                MessageBox.Show("Error while registrating!");
            }
        }
    }
}
