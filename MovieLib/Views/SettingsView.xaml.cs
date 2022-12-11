using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MovieLib.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries[0].Remove(Application.Current.Resources.MergedDictionaries[0]);
            //Application.Current.Resources.MergedDictionaries.Remove(Application.Current.Resources.MergedDictionaries.find)
            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri("/Resources/EnglishLanguage.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(newRes);
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries[0].Remove(Application.Current.Resources.MergedDictionaries[0]);
            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri("/Resources/SerbianLanguage.xaml",  UriKind.Relative);
            Application.Current.Resources.MergedDictionaries.Add(newRes);
        }
    }
}
