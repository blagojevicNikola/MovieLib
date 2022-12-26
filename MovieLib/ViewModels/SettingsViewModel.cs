using MovieLib.Commands;
using MovieLib.Models;
using MovieLib.Repositories.Impl;
using MovieLib.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MovieLib
{
    public class SettingsViewModel : BaseViewModel
    {
        private Person _person;

        public string LightDesc { get; } = "Light";
        public string DarkDesc { get; } = "Dark";
        public string CustomDesc { get; } = "Custom";
        public string SerbianDesc { get; } = "Serbian";
        public string EnglishDesc { get; } = "English";
        public bool Light { get; set; } = false;
        public bool Dark { get; set; } = false;
        public bool Blue { get; set; } = false;
        public bool English { get; set; } = false;  
        public bool Serbian { get; set; } = false;
        public ICommand LogOutCommand { get; set; }
        public ICommand SetLanguageCommand { get; set; }
        public ICommand SetThemeCommand { get; set; }

        public SettingsViewModel(NavigationStore navigationStore, Person person)
        {
            _person = person;
            setSettings(person);
            LogOutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
            SetLanguageCommand = new ParameterCommand<string>(setLanguage);
            SetThemeCommand = new ParameterCommand<string>(setTheme);
        }

        private void setSettings(Person person)
        {
            if(person.Language=="en")
            {
                English = true;  
            }
            else
            {
                Serbian = true;
            }
            switch (person.Theme)
            { 
                case "Light":
                    Light = true;
                    break;
                case "Dark":
                    Dark= true;
                    break;
                case "Custom":
                    Blue= true;
                    break;
                default:
                    Light = true;
                    break;
            }
        }

        private void setLanguage(string language)
        {
            IUserRepository userRep = new UserRepository();
            try
            {
                if (language == "English")
                {
                    userRep.UpdateLanguage(1, _person.Id!.Value);
                    _person.Language = "en";
                }
                else
                {
                    userRep.UpdateLanguage(2, _person.Id!.Value);
                    _person.Language = "srb";
                }
            }catch(MySqlException)
            {
                MessageBox.Show("Error while updating language preference!");
            }
        }
        private void setTheme(string theme)
        {
            IUserRepository userRep = new UserRepository();
            try
            {
                switch (theme)
                {
                    case "Dark":
                        {
                            userRep.UpdateTheme(1, _person.Id!.Value);
                            _person.Theme = "Dark";
                            break;
                        }
                    case "Light":
                        {
                            userRep.UpdateTheme(2, _person.Id!.Value);
                            _person.Theme = "Light";
                            break;
                        }
                    case "Custom":
                        {
                            userRep.UpdateTheme(3, _person.Id!.Value);
                            _person.Theme = "Custom";
                            break;
                        }
                    default:
                        break;
                }
            }catch(MySqlException)
            {
                MessageBox.Show("Error while updating theme preference!");
            }
        }
    }
}
