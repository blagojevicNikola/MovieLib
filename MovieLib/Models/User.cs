using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public bool Blocked { get; set; }
        public string Theme { get; set; }
        public string Language { get; set; }
        public User(int? id, string name, string surname, string username, bool blocked, string theme, string language)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Username = username;
            Blocked = blocked;
            Theme = theme;
            Language = language;
        }
    }
}
