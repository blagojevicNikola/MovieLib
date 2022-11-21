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
    public class UserMainViewModel : BaseViewModel
    {
        private User _user;
        private NavigationStore _navigationStore;
        public BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public User User { get { return _user; } set { _user = value; } }
        public ICommand ToMoviesCommand { get; set; }
        public ICommand ToPlaylistsCommand { get; set; }
        public ICommand ToSettingsCommand { get; set; }

        public UserMainViewModel(NavigationStore navigationStore, User user)
        {
            _navigationStore = navigationStore;
            ToMoviesCommand = new NavigateCommand<MoviesUserViewModel>(navigationStore, () => new MoviesUserViewModel(navigationStore));
            ToPlaylistsCommand = new RelyCommand(() => { });
            ToSettingsCommand = new RelyCommand(() => { });
            _user = user;
        }
    }
}
