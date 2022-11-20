using MovieLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieLib
{
    public class AdminUserItemViewModel : BaseViewModel
    {
        public User User { get; set; }

        public ICommand BlockUnblockCommand { get; set; }
        public AdminUserItemViewModel(User user) 
        {
            this.User = user;
            BlockUnblockCommand = new RelyCommand(() => blockUnblock());
        }

        private void blockUnblock()
        {

        }
    }
}
