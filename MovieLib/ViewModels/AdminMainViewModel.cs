using MovieLib.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieLib
{
    public class AdminMainViewModel : BaseViewModel
    {
        public BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                NotifyPropertyChanged("CurrentViewModel");
            }
        }

        ICommand ToMoviesCommand { get; set; }
        ICommand ToUsersCommand { get; set; }
        ICommand ToSettingsCommand { get; set; }
        public AdminMainViewModel(NavigationStore navigationStore)
        {
            ToMoviesCommand = new RelyCommand(() => { });
            ToUsersCommand = new RelyCommand(() => { });
            ToSettingsCommand = new RelyCommand(() => { });
        }
    }
}
