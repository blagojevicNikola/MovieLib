﻿using MovieLib.Commands;
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
    public class MoviesAdminViewModel : BaseViewModel
    {
        private Admin _admin;
        private NavigationStore _navigationStore;
        private ObservableCollection<AdminMovieItemViewModel> _movies;
        public ObservableCollection<AdminMovieItemViewModel> Movies { get { return _movies; } set { _movies = value; NotifyPropertyChanged("Movies"); } }

        public ICommand ToAddMovieCommand { get; set; }
        public MoviesAdminViewModel(NavigationStore navigationStore, Admin admin)
        {
            IMovieRepository movieRep = new MovieRepository();
            _navigationStore = navigationStore;
            ToAddMovieCommand = new NavigateCommand<AddMovieViewModel>(navigationStore, () => new AddMovieViewModel(navigationStore,admin));
            _admin = admin;
            _movies = new ObservableCollection<AdminMovieItemViewModel>();
            foreach(Movie m in movieRep.GetAll())
            {
                _movies.Add(new AdminMovieItemViewModel(m,navigationStore, _movies));
            }
        }
    }
}
