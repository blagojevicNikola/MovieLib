using MovieLib.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieLib
{
    public class AddMovieViewModel : BaseViewModel
    {

        public ICommand BackToMoviesCommand { get; set; }

        public AddMovieViewModel(NavigationStore navigationStore)
        {
            BackToMoviesCommand = new NavigateCommand<MoviesAdminViewModel>(navigationStore, () => new MoviesAdminViewModel(navigationStore));
        }
    }
}
