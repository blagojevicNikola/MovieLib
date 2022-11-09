using MovieLib.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieLib
{
    public class RegisterViewModel : BaseViewModel
    {
        public ICommand BackToLoginCommand { get; set; }

        public RegisterViewModel(NavigationStore navigationStore)
        {
            BackToLoginCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
        }
    }
}
