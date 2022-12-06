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
    public class PlaylistViewModel : BaseViewModel
    {
        private User _user;
        private NavigationStore _navigationStore;
        public ObservableCollection<Movie> Movies { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand RemoveMovieCommand { get; set; }
        public PlaylistViewModel(NavigationStore navigationStore, User user) 
        {
            _navigationStore = navigationStore;
            _user = user;
            IMovieRepository movieRep = new MovieRepository();
            Movies = (ObservableCollection<Movie>)movieRep.GetAllInPlaylist(user.Id!.Value);
            OpenCommand = new ParameterCommand<Movie>(openMovie);
            RemoveMovieCommand = new ParameterCommand<Movie>(removeMovie);
        }

        private void openMovie(Movie movie)
        {
            ICommand OpenMovieCommand = new NavigateCommand<MoviePageViewModel>(_navigationStore, () => new MoviePageViewModel(_navigationStore, _user, movie, true));
            OpenMovieCommand.Execute(null);
        }

        private void removeMovie(Movie movie) {
            IUserRepository userRep = new UserRepository();
            if(userRep.RemoveMovieFromPlaylist(movie.Id!.Value, _user!.Id.Value)) 
            {
                Movies.Remove(movie);
            }
        }

    }
}
