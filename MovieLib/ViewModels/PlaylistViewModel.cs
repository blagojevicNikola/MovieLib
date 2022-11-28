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
    public class PlaylistViewModel : BaseViewModel
    {
        private User _user;

        public ObservableCollection<Movie> Movies { get; set; }
        public PlaylistViewModel(NavigationStore navigationStore, User user) 
        {
            _user = user;
            IMovieRepository movieRep = new MovieRepository();
            Movies = (ObservableCollection<Movie>)movieRep.GetAllInPlaylist(user.Id!.Value);
        }
    }
}
