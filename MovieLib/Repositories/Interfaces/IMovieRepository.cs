using MovieLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Repositories.Interfaces
{
    interface IMovieRepository
    {
        public IEnumerable<Movie> GetAll();
        public IEnumerable<Movie> GetAllOutsidePlaylist(int userId);
        public IEnumerable<Movie> GetAllInPlaylist(int userId);
        public Movie? GetById(int id);
        public Movie? Create(Movie movie, int adminId, IList<MovieType> types);
        public bool Delete(int id);
        public bool Update(Movie movie, IList<MovieType> types);
    }
}
