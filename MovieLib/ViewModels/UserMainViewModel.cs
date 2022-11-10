using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieLib
{
    public class UserMainViewModel : BaseViewModel
    {
        public BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel {
            get { return _currentViewModel; }   
            set { _currentViewModel = value;
                NotifyPropertyChanged("CurrentViewModel");
            }
        }

        ICommand ToMoviesCommand { get; set; }
        ICommand ToPlaylistsCommand { get; set; }
        ICommand ToSettingsCommand { get; set; }

        public UserMainViewModel(NavigationStore navigationStore)
        {
            ToMoviesCommand = new RelyCommand(() => { });
            ToPlaylistsCommand = new RelyCommand(() => { });
            ToSettingsCommand = new RelyCommand(() => { });
        }
    }
}
