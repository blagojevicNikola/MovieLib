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
using System.Windows.Input;

namespace MovieLib
{
    public class LoginViewModel:BaseViewModel
    {
        public string? Username { get; set; }    
        public string? Password { get; set; }
        public ICommand ToUserViewCommand { get; set; }
        public ICommand ToAdminViewCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
       
        public LoginViewModel(NavigationStore navigationStore)
        {
            RegisterCommand = new NavigateCommand<RegisterViewModel>(navigationStore, () => new RegisterViewModel(navigationStore));
            ToAdminViewCommand = new NavigateCommand<AdminMainViewModel>(navigationStore, () => {
                NavigationStore navigationStore1 = new();
                navigationStore1.CurrentViewModel = new MoviesAdminViewModel(navigationStore1);
                return new AdminMainViewModel(navigationStore1);
            });
            ToUserViewCommand = new NavigateCommand<UserMainViewModel>(navigationStore, () =>
            {
                NavigationStore navigationStore2 = new();
                navigationStore2.CurrentViewModel = new MoviesUserViewModel(navigationStore2);
                return new UserMainViewModel(navigationStore2);
            });
            LoginCommand = new RelyCommand(() => loggingIn());
        }


        private void loggingIn()
        {
            IAuthenticationRepository rep = new AuthenticationRepository();
            try
            {
                Admin? admin = rep.LoginAdmin(Username, Password);
                if (admin is null)
                {
                    User? user = rep.LoginUser(Username, Password);
                    if (user is not null)
                        ToUserViewCommand.Execute(null);
                    
                }
                else
                {
                    ToAdminViewCommand.Execute(null);
                }

            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            
        }
    }
}
