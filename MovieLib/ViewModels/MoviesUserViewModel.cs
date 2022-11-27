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
        private ObservableCollection<Movie> _movies;
        private NavigationStore _navigationStore;
        private User _user;
        public ObservableCollection<Movie> Movies { get { return _movies; } set { _movies = value; NotifyPropertyChanged("Movies"); } }
        public ICommand AddToPlaylistCommand { get; set; }
        public ICommand OnMovieCommand { get; set; }
        public MoviesUserViewModel(NavigationStore navigationStore, User user)
        {
            _navigationStore = navigationStore;
            IMovieRepository movieRep = new MovieRepository();
            _movies = (ObservableCollection<Movie>)movieRep.GetAll();
            _user = user;
            AddToPlaylistCommand = new ParameterCommand<Movie>(addMovieToPlaylist);
            OnMovieCommand = new ParameterCommand<Movie>(onMovie);
        }

        public void addMovieToPlaylist(Movie movie)
        {
            IUserRepository userRep = new UserRepository();
            if(userRep.AddMovieToPlaylist(movie, _user))
            {
                Movies.Remove(movie);
            }
        }

        public void onMovie(Movie movie)
        {
            ICommand OpenMovieCommand = new NavigateCommand<MoviePageViewModel>(_navigationStore, () => new MoviePageViewModel(_navigationStore, _user, movie));
            OpenMovieCommand.Execute(null);
        }

    }
}
