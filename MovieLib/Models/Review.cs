using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Models
{
    public class Review
    {
        public string Username { get; set; }
        public string PostDate { get; set; }
        public string? Comment { get; set; }
        public string Rate { get; set; }

        public Review(string username, DateTime postDate, string? comment, decimal rate)
        {
            Username = username;
            PostDate = postDate.ToString("dd/MM/yyyy");
            Comment = comment;
            NumberFormatInfo info = new NumberFormatInfo();
            info.NumberDecimalDigits = 2;
            Rate = rate.ToString("N",info);
        }
    }
}
