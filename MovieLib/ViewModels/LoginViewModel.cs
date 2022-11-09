using MovieLib.Commands;
using MovieLib.Views;
using System;
using System.Collections.Generic;
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
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
       
        public LoginViewModel(NavigationStore navigationStore)
        {
            RegisterCommand = new NavigateCommand<RegisterViewModel>(navigationStore, () => new RegisterViewModel(navigationStore));
            ToUserViewCommand = new NavigateCommand<UserMainViewModel>(navigationStore, () => new UserMainViewModel(navigationStore));
            LoginCommand = new RelyCommand(() => ToUserViewCommand.Execute(null));
        }

    }
}
