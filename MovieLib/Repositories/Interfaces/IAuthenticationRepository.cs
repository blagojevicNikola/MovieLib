using MovieLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Repositories.Interfaces
{
    public interface IAuthenticationRepository
    {
        public User? LoginUser(string username, string password);
        public Admin? LoginAdmin(string username, string password);
        public User? RegisterUser(User user, string password);
    }
}
