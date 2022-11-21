using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MovieLib.Models
{
    public class MovieType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
        
        public MovieType(int id, string name, bool selected)
        {
            Id = id;
            Name = name;
            Selected = selected;
        }

        public MovieType(int id, string name)
        {
            Id = id;
            Name = name;
            Selected = false;
        }
    }
}
