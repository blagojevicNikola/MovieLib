using MovieLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }

        public MovieViewModel(Movie movie)
        {
            Movie = movie;
        }
    }
}
