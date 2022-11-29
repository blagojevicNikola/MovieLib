using MovieLib.Commands;
using MovieLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieLib
{
    public class SettingsViewModel : BaseViewModel
    {
        private User _user;

        public ICommand LogOutCommand { get; set; }

        public SettingsViewModel(NavigationStore navigationStore, User user)
        {
            _user = user;
            LogOutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
        }
    }
}
