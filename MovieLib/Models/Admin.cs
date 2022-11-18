using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Models
{
    public class Admin
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public Admin(int? id, string name, string surname, string username)
        {
            Id=id;
            Name=name;
            Surname=surname;
            Username=username;
        }
    }
}
