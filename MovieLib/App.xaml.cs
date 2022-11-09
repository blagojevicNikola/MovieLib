using MovieLib.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MovieLib
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new();
            navigationStore.CurrentViewModel = new LoginViewModel(navigationStore);
            MainWindow win = new()
            {
                DataContext = new MainWindowViewModel(navigationStore)
            };
            win.Show();
            base.OnStartup(e);
        }

    }
}
