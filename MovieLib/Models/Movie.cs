using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Models
{
    public class Movie
    {
        public int? Id { get; set; } 
        public string Title { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public DateTime? Published { get; set; }
        public string? Uri { get; set; }
        public string Rating { get; set; }

        public Movie(int? id, string title, string director, string description, DateTime? published, string? uri, decimal rating)
        {
            NumberFormatInfo info = new NumberFormatInfo();
            info.NumberDecimalDigits = 2;
            Rating = rating.ToString("N", info);    
            Id = id;
            Title = title;
            Director = director;
            Description = description;
            Published = published;
            Uri = uri;
        }

    }
}
