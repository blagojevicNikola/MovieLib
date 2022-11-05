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
        private BaseViewModel _currentViewModel = new LoginViewModel();
        public BaseViewModel CurrentViewModel { 
            get { return _currentViewModel; } 
            set { _currentViewModel = value; NotifyPropertyChanged("CurrentViewModel"); } 
        }

        public ICommand RegisterCommand { get; set; }  
        public ICommand BackToLoginCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        public MainWindowViewModel()
        {
            RegisterCommand = new RelyCommand(() => { CurrentViewModel = new RegisterViewModel(); });
            BackToLoginCommand = new RelyCommand(() => { CurrentViewModel = new LoginViewModel(); });
            CloseCommand = new RelyCommand(() => shutdown());
        }


        public void shutdown()
        {
            Application.Current.Shutdown();
        }
    }
}
