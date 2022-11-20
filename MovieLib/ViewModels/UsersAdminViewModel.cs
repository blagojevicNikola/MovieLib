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
        private ObservableCollection<AdminUserItemViewModel> _users;
        public ObservableCollection<AdminUserItemViewModel> Users { get { return _users; } set { _users = value; NotifyPropertyChanged("Users"); } }

        public UsersAdminViewModel()
        {
            IUserRepository userRep = new UserRepository();
            _users = new ObservableCollection<AdminUserItemViewModel>();
            foreach(User u in userRep.GetAll())
            {
                _users.Add(new AdminUserItemViewModel(u));
            }
        }
    }
}
