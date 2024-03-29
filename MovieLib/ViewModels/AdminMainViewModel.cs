﻿using MovieLib.Commands;
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
    public class AdminMainViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private Admin _admin;
        public Admin Admin { get { return _admin; } set { _admin = value; } }

        public BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        
        public ICommand ToMoviesCommand { get; set; }
        public ICommand ToUsersCommand { get; set; }
        public ICommand ToSettingsCommand { get; set; }
        public AdminMainViewModel(NavigationStore mainWindowNav,NavigationStore navigationStore, Admin admin)
        {
            _admin = admin;
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += CurrentPropertyChanged;
            ToMoviesCommand = new NavigateCommand<MoviesAdminViewModel>(navigationStore, () => new MoviesAdminViewModel(navigationStore,admin));
            ToUsersCommand = new NavigateCommand<UsersAdminViewModel>(navigationStore, () => new UsersAdminViewModel());
            ToSettingsCommand = new NavigateCommand<SettingsViewModel>(navigationStore, () => new SettingsViewModel(mainWindowNav, _admin));
        }

        private void CurrentPropertyChanged()
        {
            NotifyPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
