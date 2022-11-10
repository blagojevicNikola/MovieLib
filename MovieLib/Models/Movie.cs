using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Models
{
    public class Movie
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public DateTime Published { get; set; }
        public string? Uri { get; set; }

        public Movie()
        {

        }
    }
}
