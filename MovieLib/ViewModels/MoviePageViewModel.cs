using MovieLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    public class MoviePageViewModel : BaseViewModel
    {
        private User _user;
        public MoviePageViewModel(User user)
        {
            _user = user;
        }
    }
}
