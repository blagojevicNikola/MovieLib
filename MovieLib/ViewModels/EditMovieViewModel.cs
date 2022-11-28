using MovieLib.Commands;
using MovieLib.Models;
using MovieLib.Repositories.Impl;
using MovieLib.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieLib
{
    public class EditMovieViewModel : BaseViewModel
    {
        private string _title;
        private string _description;
        private string _director;
        private string _publishDate;
        private string? _uri;
        private Movie _movie;
        public string Title { get { return _title; } set { _title = value; NotifyPropertyChanged("Title"); } }
        public string Director { get { return _director; } set { _director = value; NotifyPropertyChanged("Director"); } }
        public string Description { get { return _description; } set { _description = value; NotifyPropertyChanged("Description"); } }
        public string PublishDate { get { return _publishDate; } set { _publishDate = value; NotifyPropertyChanged("PublishedDate"); } }
        public string? Uri { get { return _uri; } set { _uri = value; NotifyPropertyChanged("Uri"); } }
        public ICommand BackToMoviesCommand { get; set; }
        public ICommand UpdateMovieCommand { get; set; }
        public EditMovieViewModel(NavigationStore navigationStore, Admin admin, Movie movie)
        {
            _movie = movie;
            BackToMoviesCommand = new NavigateCommand<MoviesAdminViewModel>(navigationStore, () => new MoviesAdminViewModel(navigationStore, admin));

        }

        public void udpateMovie()
        {
            IMovieRepository movieRep = new MovieRepository();
            DateTime? published = null;
            if(DateTime.TryParse(PublishDate, out _))
            {
                published = DateTime.Parse(PublishDate);
            }
            Movie updatedMovie = new Movie(_movie.Id, Title, Director, Description, published, Uri, decimal.Parse(_movie.Rating));
            movieRep.Update(updatedMovie);
        }
    }
}
