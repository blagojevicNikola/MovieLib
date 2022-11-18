using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Repositories
{
    public abstract class RepositoryBase
    {
        protected RepositoryBase() { }

        public MySqlConnection GetConnection() { 
            return new MySqlConnection(ConfigurationManager.ConnectionStrings["MovieLibDb"].ConnectionString);
        }
    }
}
