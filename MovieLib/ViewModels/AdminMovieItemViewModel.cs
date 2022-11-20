using MovieLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieLib
{
    public class AdminMovieItemViewModel : BaseViewModel
    {
        private IEnumerable<AdminMovieItemViewModel> _movies;
        public Movie Movie { get; set; }

        public ICommand DeleteMovieCommand { get; set; }
        public ICommand UpdateMovieCommand { get; set; }
        
        public AdminMovieItemViewModel(Movie movie, NavigationStore navigationStore, IEnumerable<AdminMovieItemViewModel> movies)
        {
            Movie = movie;
            _movies = movies;
        }

        private void deleteMovie()
        {

        }

    }
}
