using MovieLib.Models;
using MovieLib.Repositories.Impl;
using MovieLib.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    public class UsersAdminViewModel : BaseViewModel
    {
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users { get { return _users; } set { _users = value; NotifyPropertyChanged("Users"); } }

        public UsersAdminViewModel()
        {
            IUserRepository userRep = new UserRepository();
            _users = (ObservableCollection<User>)userRep.GetAll();
        }
    }
}
