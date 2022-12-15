using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Models
{
    public class User:Person,INotifyPropertyChanged
    {
        private bool _blocked = false;
        
        public bool Blocked { get { return _blocked; } set { _blocked = value; NotifyPropertyChanged("Blocked"); } }

        public User(int? id, string name, string surname, string username, bool blocked, string theme, string language):base(id, name, surname, username, theme, language)
        {
            Blocked = blocked;
        }
    }
}
