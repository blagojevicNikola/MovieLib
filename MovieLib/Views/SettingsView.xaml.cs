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
            Application.Current.Resources.MergedDictionaries[0].MergedDictionaries.Remove(Application.Current.Resources.MergedDictionaries[0].MergedDictionaries[0]);
            //Application.Current.Resources.MergedDictionaries.Remove(Application.Current.Resources.MergedDictionaries.find)
            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri("/Resources/EnglishLanguage.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries[0].MergedDictionaries.Add(newRes);
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries[0].MergedDictionaries.Remove(Application.Current.Resources.MergedDictionaries[0].MergedDictionaries[0]);
            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri("/Resources/SerbianLanguage.xaml",  UriKind.Relative);
            Application.Current.Resources.MergedDictionaries[0].MergedDictionaries.Add(newRes);
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries[1].MergedDictionaries.Remove(Application.Current.Resources.MergedDictionaries[1].MergedDictionaries[0]);
            //Application.Current.Resources.MergedDictionaries.Remove(Application.Current.Resources.MergedDictionaries.find)
            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri("/Resources/DarkTheme.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries[1].MergedDictionaries.Add(newRes);
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries[1].MergedDictionaries.Remove(Application.Current.Resources.MergedDictionaries[1].MergedDictionaries[0]);
            //Application.Current.Resources.MergedDictionaries.Remove(Application.Current.Resources.MergedDictionaries.find)
            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri("/Resources/LightTheme.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries[1].MergedDictionaries.Add(newRes);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RadioButton_Checked(sender, e);
            RadioButton_Checked_2(sender, e);
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries[1].MergedDictionaries.Remove(Application.Current.Resources.MergedDictionaries[1].MergedDictionaries[0]);
            //Application.Current.Resources.MergedDictionaries.Remove(Application.Current.Resources.MergedDictionaries.find)
            ResourceDictionary newRes = new ResourceDictionary();
            newRes.Source = new Uri("/Resources/CustomTheme.xaml", UriKind.Relative);
            Application.Current.Resources.MergedDictionaries[1].MergedDictionaries.Add(newRes);
        }
    }
}
