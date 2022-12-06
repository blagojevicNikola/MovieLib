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
    public class MoviePageViewModel : BaseViewModel
    {
        private User _user;
        public Movie Movie { get; set; }
        public ICommand BackToMoviesCommand { get; set; }
        public MoviePageViewModel(NavigationStore navigationStore, User user, Movie movie, bool fromPlaylist)
        {
            _user = user;
            if(!fromPlaylist) 
            {
                BackToMoviesCommand = new NavigateCommand<MoviesUserViewModel>(navigationStore, () => new MoviesUserViewModel(navigationStore, user));
            }
            else
            {
                BackToMoviesCommand = new NavigateCommand<PlaylistViewModel>(navigationStore, () => new PlaylistViewModel(navigationStore, user));
            }
            Movie = movie; 
        }
    }
}
