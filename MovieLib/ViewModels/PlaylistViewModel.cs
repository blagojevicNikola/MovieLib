using MovieLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    public class PlaylistViewModel : BaseViewModel
    {
        private User _user;
        public PlaylistViewModel(NavigationStore navigationStore, User user) 
        {
            _user = user;
        }
    }
}
