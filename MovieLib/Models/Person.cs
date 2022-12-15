using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Models
{
    public abstract class Person : INotifyPropertyChanged
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Theme { get; set; }
        public string Language { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Person(int? id, string name, string surname, string username, string theme, string language)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Username = username;
            Theme = theme;
            Language = language;
        } 

        public void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
