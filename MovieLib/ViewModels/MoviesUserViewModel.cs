using MovieLib.Commands;
using MovieLib.Models;
using MovieLib.Repositories.Impl;
using MovieLib.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        private bool _byName = true;
        private bool _popular = false;
        private bool _recent = false;
        private User _user;
        public ObservableCollection<Movie> Movies { get { return _movies; } set { _movies = value; NotifyPropertyChanged("Movies"); } }
        public ObservableCollection<MovieType> Types { get { return _types; } set { _types = value; NotifyPropertyChanged("Types"); } }
        public bool ByName { get { return _byName; } set { _byName = value; NotifyPropertyChanged("ByName"); } }
        public bool Popular { get { return _popular; } set { _popular = value; NotifyPropertyChanged("Popular"); } }
        public bool Recent { get { return _recent; } set { _recent = value; NotifyPropertyChanged("Recent"); } }
        public ICommand AddToPlaylistCommand { get; set; }
        public ICommand OnMovieCommand { get; set; }
        public ICommand SelectTypeCommand { get; set; }
        public ICommand AllMoviesCommand { get; set; }
        public ICommand OrderByNameCommand { get; set; }
        public ICommand OrderByPopularityCommand { get; set; }
        public ICommand OrderByDateCommand { get; set; }
        public MoviesUserViewModel(NavigationStore navigationStore, User user)
        {
            _navigationStore = navigationStore;
            IMovieRepository movieRep = new MovieRepository();
            IMovieTypeRepository movieTypeRep = new MovieTypeRepository();
            _movies = (ObservableCollection<Movie>)movieRep.GetAllOutsidePlaylist(user.Id!.Value, "Title");
            _types = (ObservableCollection<MovieType>)movieTypeRep.GetAll();
            _user = user;
            AddToPlaylistCommand = new ParameterCommand<Movie>(addMovieToPlaylist);
            OnMovieCommand = new ParameterCommand<Movie>(onMovie);
            SelectTypeCommand = new ParameterCommand<MovieType>(getSpecificType);
            AllMoviesCommand = new RelyCommand(getAllMovies);
            OrderByNameCommand = new RelyCommand(orderByName);
            OrderByPopularityCommand = new RelyCommand(orderByPopularity);
            OrderByDateCommand = new RelyCommand(orderByDate);
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
            if(ByName)
            {
                Movies = (ObservableCollection<Movie>)movieRep.GetAllOfType(type.Id, _user.Id!.Value, "Title");
            } else if(Popular)
            {
                Movies = (ObservableCollection<Movie>)movieRep.GetAllOfType(type.Id, _user.Id!.Value, "Rating");
            }else
            {
                Movies = (ObservableCollection<Movie>)movieRep.GetAllOfType(type.Id, _user.Id!.Value, "PublishDate");
            }
        }

        private void getAllMovies()
        {
            IMovieRepository movieRep = new MovieRepository();
            if (ByName)
            {
                Movies = (ObservableCollection<Movie>)movieRep.GetAllOutsidePlaylist(_user.Id!.Value, "Title");
            }
            else if (Popular)
            {
                Movies = (ObservableCollection<Movie>)movieRep.GetAllOutsidePlaylist(_user.Id!.Value, "Rating");
            }
            else
            {
                Movies = (ObservableCollection<Movie>)movieRep.GetAllOutsidePlaylist(_user.Id!.Value, "PublishDate");
            }
        }

        private void orderByName()
        {
            ObservableCollection<Movie> newList = new ObservableCollection<Movie>();
            var ordered = Movies.ToList().OrderBy(s => s.Title);
            foreach(var movie in ordered)
            {
                newList.Add(movie);
            }
            Movies = newList;
        }

        private void orderByPopularity()
        {
            ObservableCollection<Movie> newList = new ObservableCollection<Movie>();
            var ordered = Movies.ToList().OrderBy(s => s.Rating).Reverse();
            foreach (var movie in ordered)
            {
                newList.Add(movie);
            }
            Movies = newList;
        }

        private void orderByDate()
        {
            ObservableCollection<Movie> newList = new ObservableCollection<Movie>();
            var ordered = Movies.ToList().OrderBy(s => s.Published).Reverse();
            foreach (var movie in ordered)
            {
                newList.Add(movie);
            }
            Movies = newList;
        }
    }
}
