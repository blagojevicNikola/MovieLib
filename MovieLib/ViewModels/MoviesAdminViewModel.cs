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
using System.Windows;
using System.Windows.Input;

namespace MovieLib
{
    public class MoviesAdminViewModel : BaseViewModel
    {
        private Admin _admin;
        private NavigationStore _navigationStore;
        private ObservableCollection<Movie> _movies;
        public ObservableCollection<Movie> Movies { get { return _movies; } set { _movies = value; NotifyPropertyChanged("Movies"); } }

        public ICommand ToAddMovieCommand { get; set; }
        public ICommand DeleteMovieCommand { get; set; }
        public ICommand EditMovieCommand { get; set; }
        public MoviesAdminViewModel(NavigationStore navigationStore, Admin admin)
        {
            IMovieRepository movieRep = new MovieRepository();
            _navigationStore = navigationStore;
            ToAddMovieCommand = new NavigateCommand<AddMovieViewModel>(navigationStore, () => new AddMovieViewModel(navigationStore,admin));
            _admin = admin;
            _movies = (ObservableCollection<Movie>)movieRep.GetAll();
            DeleteMovieCommand = new ParameterCommand<Movie>(deleteMovie);
        }

        public void deleteMovie(Movie movie)
        {
            IMovieRepository movieRep = new MovieRepository();
            try
            {
                if (movieRep.Delete(movie.Id!.Value))
                {
                    Movies.Remove(movie);
                }
            }
            catch (MySqlException e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show("Movie cannot be deleted!");
            }
        }

        public void editMovie(Movie movie)
        {
        }
    }
}
