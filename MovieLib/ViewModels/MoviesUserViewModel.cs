using MovieLib.Commands;
using MovieLib.Models;
using MovieLib.Repositories.Impl;
using MovieLib.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieLib
{
    public class MoviesUserViewModel : BaseViewModel
    {
        private ObservableCollection<MovieViewModel> _movies;
        private NavigationStore _navigationStore;
        private User _user;
        public ObservableCollection<MovieViewModel> Movies { get { return _movies; } set { _movies = value; NotifyPropertyChanged("Movies"); } }
        public ICommand OpenMovieCommand { get; set; }
        public ICommand AddToPlaylistCommand { get; set; }
        public MoviesUserViewModel(NavigationStore navigationStore, User user)
        {
            _navigationStore = navigationStore;
            _movies = new ObservableCollection<MovieViewModel>();
            IMovieRepository movieRep = new MovieRepository();
            foreach (Movie m in movieRep.GetAll())
            {
                Movies.Add(new MovieViewModel(m));
            }
            _user = user;
            OpenMovieCommand = new NavigateCommand<MoviePageViewModel>(_navigationStore, () => new MoviePageViewModel(_user));
            AddToPlaylistCommand = new ParameterCommand<MovieViewModel>(addMovieToPlaylist);
        }

        public void addMovieToPlaylist(MovieViewModel movie)
        {
            IUserRepository userRep = new UserRepository();
            if(userRep.AddMovieToPlaylist(movie.Movie, _user))
            {
                Movies.Remove(movie);
            }
        }
    }
}
