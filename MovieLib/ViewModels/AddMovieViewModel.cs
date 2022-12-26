using Microsoft.Win32;
using MovieLib.Commands;
using MovieLib.Models;
using MovieLib.Repositories.Impl;
using MovieLib.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MovieLib
{
    public class AddMovieViewModel : BaseViewModel
    {
        private Admin _admin;
        private string _title;
        private string _director;
        private string _description;
        private string _publishDate;
        private string? _uri;

        public string Title { get { return _title; } set { _title = value; NotifyPropertyChanged("Title"); } }
        public string Director { get { return _director; } set { _director = value; NotifyPropertyChanged("Director"); } }
        public string Description { get { return _description; } set { _description = value; NotifyPropertyChanged("Description"); } }
        public string PublishDate { get { return _publishDate; }set { _publishDate = value; NotifyPropertyChanged("PublishedDate"); } }
        public string? Uri { get { return _uri; } set { _uri = value; NotifyPropertyChanged("Uri"); } }
        public ObservableCollection<MovieType> AllTypes { get; set; }
        public ICommand BackToMoviesCommand { get; set; }
        public ICommand LoadImageCommand { get; set; }
        public ICommand AddMovieCommand { get; set; }

        public AddMovieViewModel(NavigationStore navigationStore, Admin admin)
        {
            BackToMoviesCommand = new NavigateCommand<MoviesAdminViewModel>(navigationStore, () => new MoviesAdminViewModel(navigationStore,admin));
            LoadImageCommand = new RelyCommand(() => loadImage());
            AddMovieCommand = new RelyCommand(() => addMovie());
            _admin = admin;
            IMovieTypeRepository movieTypeRep = new MovieTypeRepository();
            AllTypes = (ObservableCollection<MovieType>)movieTypeRep.GetAll();
        }

        private void loadImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == true)
            {
                Uri = dialog.FileName;
            }
        }

        private void addMovie()
        {
            DateTime? publishedTime = null;
            if(DateTime.TryParse(PublishDate, out _))
            {
                publishedTime = DateTime.ParseExact(PublishDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            if (string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Director))
            {
                MessageBox.Show("Title/Director is empty!");
                return;
            }
            Movie newMovie = new Movie(null, Title, Director, Description, publishedTime, Uri, new decimal(0.0));
            IMovieRepository rep = new MovieRepository();
            List<MovieType> selectedTypes = AllTypes.Where(s => s.Selected == true).ToList();
            try
            {
                if (_admin.Id.HasValue)
                {
                    int adminId = _admin.Id.Value;
                    if (rep.Create(newMovie, adminId, selectedTypes) is not null)
                    {
                        BackToMoviesCommand.Execute(null);
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Movie was not created succesfully!");
                        return;
                    }
                }
            }catch(MySqlException)
            {
                MessageBox.Show("Error while adding movie!");
            }
        }

        private bool canAdd()
        {
            if(string.IsNullOrEmpty(Title))
            {
                return false;
            }
            return true;
        }
    }
}
