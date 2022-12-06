using MovieLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAll();
        public bool BlockUser(int id);
        public bool UnblockUser(int id);
        public bool RemoveMovieFromPlaylist(int movieId, int userId);

        public bool AddMovieToPlaylist(Movie movie, User user);
    }
}
