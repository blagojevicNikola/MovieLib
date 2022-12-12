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
        private ObservableCollection<MovieType> _types;
        private NavigationStore _navigationStore;
        private User _user;
        public ObservableCollection<Movie> Movies { get { return _movies; } set { _movies = value; NotifyPropertyChanged("Movies"); } }
        public ObservableCollection<MovieType> Types { get { return _types; } set { _types = value; NotifyPropertyChanged("Types"); } }
        public ICommand AddToPlaylistCommand { get; set; }
        public ICommand OnMovieCommand { get; set; }
        public ICommand SelectTypeCommand { get; set; }
        public ICommand AllMoviesCommand { get; set; }
        public MoviesUserViewModel(NavigationStore navigationStore, User user)
        {
            _navigationStore = navigationStore;
            IMovieRepository movieRep = new MovieRepository();
            IMovieTypeRepository movieTypeRep = new MovieTypeRepository();
            _movies = (ObservableCollection<Movie>)movieRep.GetAllOutsidePlaylist(user.Id!.Value);
            _types = (ObservableCollection<MovieType>)movieTypeRep.GetAll();
            _user = user;
            AddToPlaylistCommand = new ParameterCommand<Movie>(addMovieToPlaylist);
            OnMovieCommand = new ParameterCommand<Movie>(onMovie);
            SelectTypeCommand = new ParameterCommand<MovieType>(getSpecificType);
            AllMoviesCommand = new RelyCommand(getAllMovies);
        }

        private void addMovieToPlaylist(Movie movie)
        {
            IUserRepository userRep = new UserRepository();
            if(userRep.AddMovieToPlaylist(movie, _user))
            {
                Movies.Remove(movie);
            }
        }

        private void onMovie(Movie movie)
        {
            ICommand OpenMovieCommand = new NavigateCommand<MoviePageViewModel>(_navigationStore, () => new MoviePageViewModel(_navigationStore, _user, movie, false));
            OpenMovieCommand.Execute(null);
        }

        private void getSpecificType(MovieType type)
        {
            IMovieRepository movieRep = new MovieRepository();
            Movies = (ObservableCollection<Movie>)movieRep.GetAllOfType(type.Id, _user.Id!.Value);
            
        }

        private void getAllMovies()
        {
            IMovieRepository movieRep = new MovieRepository();
            Movies = (ObservableCollection<Movie>)movieRep.GetAllOutsidePlaylist(_user.Id!.Value);
        }

    }
}
