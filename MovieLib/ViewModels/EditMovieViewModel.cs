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
    public class EditMovieViewModel : BaseViewModel
    {
        public ICommand BackToMoviesCommand { get; set; }
        public EditMovieViewModel(NavigationStore navigationStore, Admin admin, Movie movie)
        {
            BackToMoviesCommand = new NavigateCommand<MoviesAdminViewModel>(navigationStore, () => new MoviesAdminViewModel(navigationStore, admin));
        }
    }
}
