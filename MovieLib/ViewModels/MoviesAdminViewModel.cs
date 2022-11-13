using MovieLib.Commands;
using MovieLib.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieLib
{
    public class MoviesAdminViewModel : BaseViewModel
    {
        private NavigationStore _navigationStore;
        private ObservableCollection<Movie> _movies = new ObservableCollection<Movie>();
        public ObservableCollection<Movie> Movies { get { return _movies; } set { _movies = value; NotifyPropertyChanged("Movies"); } }

        public ICommand ToAddMovieCommand { get; set; }
        public MoviesAdminViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            ToAddMovieCommand = new NavigateCommand<AddMovieViewModel>(navigationStore, () => new AddMovieViewModel(navigationStore));
        }
    }
}
