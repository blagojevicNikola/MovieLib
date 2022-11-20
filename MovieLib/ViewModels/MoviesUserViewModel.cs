using MovieLib.Models;
using MovieLib.Repositories.Impl;
using MovieLib.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    public class MoviesUserViewModel : BaseViewModel
    {
        private ObservableCollection<MovieViewModel> _movies;
        private NavigationStore _navigationStore;
        public ObservableCollection<MovieViewModel> Movies { get { return _movies; } set { _movies = value; NotifyPropertyChanged("Movies"); } }

        public MoviesUserViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _movies = new ObservableCollection<MovieViewModel>();
            IMovieRepository movieRep = new MovieRepository();
            foreach(Movie m in movieRep.GetAll())
            {
                Movies.Add(new MovieViewModel(m));
            }
        }

    }
}
