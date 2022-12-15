using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Models
{
    public class Admin:Person
    {
        public Admin(int? id, string name, string surname, string username, string theme, string language):base(id,name,surname,username,theme,language)
        {

        }
    }
}
