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
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public User User { get { return _user; } set { _user = value; } }
        public ICommand ToMoviesCommand { get; set; }
        public ICommand ToPlaylistsCommand { get; set; }
        public ICommand ToSettingsCommand { get; set; }

        public UserMainViewModel(NavigationStore mainWindowNav, NavigationStore navigationStore, User user)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += CurrentPropertyChanged;
            ToMoviesCommand = new NavigateCommand<MoviesUserViewModel>(navigationStore, () => new MoviesUserViewModel(navigationStore, user));
            ToPlaylistsCommand = new NavigateCommand<PlaylistViewModel>(navigationStore, () => new PlaylistViewModel(navigationStore, user));
            ToSettingsCommand = new NavigateCommand<SettingsViewModel>(navigationStore, () => new SettingsViewModel(mainWindowNav,user));
            _user = user;
        }

        private void CurrentPropertyChanged()
        {
            NotifyPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
