using MovieLib.Models;
using MovieLib.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Repositories.Impl
{
    public class MovieTypeRepository : RepositoryBase, IMovieTypeRepository
    {
        public IEnumerable<MovieType> GetAll()
        {
            using(var conn = this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "select * from type";
                command.Connection = conn;
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                ObservableCollection<MovieType> results = new ObservableCollection<MovieType>();
                while(reader.Read()) 
                {
                    results.Add(new MovieType(reader.GetInt32(0), reader.GetString(1)));
                }
                return results; 
            }
        }
    }
}
