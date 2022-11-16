using MovieLib.Models;
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
        private ObservableCollection<Movie> _movies;
        private NavigationStore _navigationStore;
        public ObservableCollection<Movie> Movies { get { return _movies; } set { _movies = value; NotifyPropertyChanged("Movies"); } }

        public MoviesUserViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            Movies = new ObservableCollection<Movie>();
        }

    }
}
