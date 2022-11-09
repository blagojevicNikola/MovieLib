using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MovieLib
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;

        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
        public ICommand CloseCommand { get; set; }

        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += CurrentPropertyChanged;
            CloseCommand = new RelyCommand(() => shutdown());
        }

        private void CurrentPropertyChanged()
        {
            NotifyPropertyChanged(nameof(CurrentViewModel));
        }

        public void shutdown()
        {
            Application.Current.Shutdown();
        }
    }
}
