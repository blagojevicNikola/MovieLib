using MovieLib.Models;
using MovieLib.Repositories.Impl;
using MovieLib.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieLib
{
    public class UsersAdminViewModel : BaseViewModel
    {
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users { get { return _users; } set { _users = value; NotifyPropertyChanged("Users"); } }

        public  ICommand BlockUserCommand { get; set; }

        public UsersAdminViewModel()
        {
            IUserRepository userRep = new UserRepository();
            _users = (ObservableCollection<User>)userRep.GetAll();
            BlockUserCommand = new ParameterCommand<User>(blockUnblockUser);
        }

        public void blockUnblockUser(User user)
        {
            IUserRepository userRep = new UserRepository();
            if(!user.Blocked)
            {
                if (userRep.BlockUser(user.Id!.Value))
                {
                    user.Blocked = true;
                }
            }
            else
            {
                if(userRep.UnblockUser(user.Id!.Value))
                {
                    user.Blocked= false;
                }
            }
            
        }
    }
}
