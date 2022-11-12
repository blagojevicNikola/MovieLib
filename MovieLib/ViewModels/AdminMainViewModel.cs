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
    public class AdminMainViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;

        public BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        
        public ICommand ToMoviesCommand { get; set; }
        public ICommand ToUsersCommand { get; set; }
        public ICommand ToSettingsCommand { get; set; }
        public AdminMainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += CurrentPropertyChanged;
            ToMoviesCommand = new NavigateCommand<MoviesAdminViewModel>(navigationStore, () => new MoviesAdminViewModel(navigationStore));
            ToUsersCommand = new NavigateCommand<UsersAdminViewModel>(navigationStore, () => new UsersAdminViewModel());
            ToSettingsCommand = new RelyCommand(() => { });
        }

        private void CurrentPropertyChanged()
        {
            NotifyPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
