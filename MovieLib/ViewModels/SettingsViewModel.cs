using MovieLib.Commands;
using MovieLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieLib
{
    public class SettingsViewModel : BaseViewModel
    {
        private Person _person;
        public bool Light { get; set; } = false;
        public bool Dark { get; set; } = false;
        public bool Blue { get; set; } = false;
        public ICommand LogOutCommand { get; set; }

        public SettingsViewModel(NavigationStore navigationStore, Person person)
        {
            _person = person;
            setSettings(person);
            LogOutCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
        }

        private void setSettings(Person person)
        {
            if(person.Theme=="en")
            {

            }
            else
            {

            }
            switch (person.Language)
            { 
                case "light":
                    Light = true;
                    break;
                case "dark":
                    Dark= true;
                    break;
                case "blue":
                    Blue= true;
                    break;
                default:
                    Light = true;
                    break;
            }

        }
    }
}
