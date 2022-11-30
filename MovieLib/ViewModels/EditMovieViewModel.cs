using Microsoft.Win32;
using MovieLib.Commands;
using MovieLib.Models;
using MovieLib.Repositories.Impl;
using MovieLib.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public string Title { get { return _title; } set { _title = value; NotifyPropertyChanged("Title"); } }
        public string Director { get { return _director; } set { _director = value; NotifyPropertyChanged("Director"); } }
        public string Description { get { return _description; } set { _description = value; NotifyPropertyChanged("Description"); } }
        public string PublishDate { get { return _publishDate; } set { _publishDate = value; NotifyPropertyChanged("PublishedDate"); } }
        public string? Uri { get { return _uri; } set { _uri = value; NotifyPropertyChanged("Uri"); } }
        public Movie Movie { get; set; }
        public ObservableCollection<MovieType> AllTypes { get; set; }
        public ICommand BackToMoviesCommand { get; set; }
        public ICommand UpdateMovieCommand { get; set; }
        public ICommand LoadImageCommand { get; set; }
        public EditMovieViewModel(NavigationStore navigationStore, Admin admin, Movie movie)
        {
            IMovieTypeRepository movieTypeRep = new MovieTypeRepository();
            Movie = movie;
            Title = Movie.Title;
            Director = Movie.Director;
            Description = Movie.Description;
            PublishDate = Movie.Published.HasValue ? Movie.Published.Value.ToString("dd/MM/yyyy") : "";
            Uri = Movie.Uri;
            BackToMoviesCommand = new NavigateCommand<MoviesAdminViewModel>(navigationStore, () => new MoviesAdminViewModel(navigationStore, admin));
            AllTypes = (ObservableCollection<MovieType>)movieTypeRep.GetAllDependingOnMovie(movie.Id!.Value);
            UpdateMovieCommand = new RelyCommand(updateMovie);
            LoadImageCommand = new RelyCommand(loadImage);
        }

        public void updateMovie()
        {
            IMovieRepository movieRep = new MovieRepository();
            DateTime? published = null;
            if(DateTime.TryParse(PublishDate, out _))
            {
                published = DateTime.Parse(PublishDate);
            }
            Movie updatedMovie = new Movie(Movie.Id, Title, Director, Description, published, Uri, decimal.Parse(Movie.Rating));
            List<MovieType> types = AllTypes.Where(s => s.Selected == true).ToList();
            try
            {
                if (movieRep.Update(updatedMovie, types))
                {
                    BackToMoviesCommand.Execute(null);
                }
            }catch(MySqlException e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show("Error occured while editing movie!");
            }
        }

        private void loadImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                Uri = dialog.FileName;
            }
        }
    }
}
