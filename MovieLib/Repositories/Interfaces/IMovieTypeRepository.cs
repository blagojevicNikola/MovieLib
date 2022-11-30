using MovieLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Repositories.Interfaces
{
    public interface IMovieTypeRepository
    {
        public IEnumerable<MovieType> GetAll();
        public IEnumerable<MovieType> GetAllDependingOnMovie(int movieId);
    }
}
