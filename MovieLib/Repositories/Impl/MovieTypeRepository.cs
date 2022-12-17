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

        public IEnumerable<MovieType> GetAllDependingOnMovie(int movieId)
        {
            using (var conn = this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "select * from type t inner join movie_of_type o on o.Type_id=t.id where Movie_id=@movieId";
                command.Parameters.AddWithValue("@movieId", movieId);
                command.Connection = conn;
                conn.Open();
                ObservableCollection<MovieType> results = new ObservableCollection<MovieType>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new MovieType(reader.GetInt32(0), reader.GetString(1), true));
                    }
                }
                command.CommandText = "select * from type where id not in (select id from type t inner join movie_of_type o on o.Type_id=t.id where Movie_id=@movieId)";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new MovieType(reader.GetInt32(0), reader.GetString(1), false));

                    }
                }
                return results;
            }
        }

        public IEnumerable<MovieType> GetMovieTypes(int movieId)
        {
            using (var conn = this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.CommandText = "select * from type t inner join movie_of_type o on o.Type_id=t.id where Movie_id=@movieId";
                command.Parameters.AddWithValue("@movieId", movieId);
                command.Connection = conn;
                conn.Open();
                ObservableCollection<MovieType> results = new ObservableCollection<MovieType>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new MovieType(reader.GetInt32(0), reader.GetString(1), true));
                    }
                }
                return results;
            }
        }
    }
}
