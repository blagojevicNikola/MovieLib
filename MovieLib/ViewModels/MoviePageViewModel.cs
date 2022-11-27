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
        private Movie _movie;
        public ICommand BackToMoviesCommand { get; set; }
        public MoviePageViewModel(NavigationStore navigationStore, User user, Movie movie)
        {
            _user = user;
            BackToMoviesCommand = new NavigateCommand<MoviesUserViewModel>(navigationStore, () => new MoviesUserViewModel(navigationStore, user));
            _movie = movie; 
        }
    }
}
