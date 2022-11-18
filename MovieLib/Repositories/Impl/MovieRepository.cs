using MovieLib.Models;
using MovieLib.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Repositories.Impl
{
    public class MovieRepository : RepositoryBase,IMovieRepository
    {
        public Movie? Create(Movie movie, int adminId)
        {
            using (var conn = this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "insert into movie(Title, Director, Description, PublishDate, ImageUri, Admin_Person_id) values(@title,@director,@description,@publish_date,@image_uri,@admin_id)";
                command.Parameters.AddWithValue("@title", movie.Title);
                command.Parameters.AddWithValue("@director", movie.Director);
                command.Parameters.AddWithValue("@description", movie.Description);
                command.Parameters.AddWithValue("@public_date", movie.Published);
                command.Parameters.AddWithValue("@image_uri", movie.Uri);
                command.Parameters.AddWithValue("@admin_id", adminId);
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                Movie? result = null;
                if (reader.Read())
                {
                    result = new Movie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5), reader.GetDecimal(6));
                }
                return result;
            }
        }

        public bool Delete(int id)
        {
            using (var conn = this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "delete from movie where id=@id";
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public IEnumerable<Movie> GetAll()
        {
            using(var conn = this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "select * from movie_info";
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                ObservableCollection<Movie> result = new ObservableCollection<Movie>();
                while(reader.Read())
                {
                    result.Add(new Movie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5), reader.GetDecimal(6)));
                }
                return result;
            }
        }

        public Movie? GetById(int id)
        {
            using (var conn = this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand(); 
                command.Connection = conn;
                command.CommandText = "select * from movie_info where id=@id";
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                Movie? result = null;
                if(reader.Read())
                { 
                    result = new Movie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5), reader.GetDecimal(6));
                }
                return result;
            }
        }

        public bool Update(Movie movie)
        {
            using (var conn = this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "update movie set Title=@title, Director=@director, Description=@description, PublishDate=@publish_date, ImageUri=@image_uri where id=@id";
                command.Parameters.AddWithValue("@title", movie.Title);
                command.Parameters.AddWithValue("@director", movie.Director);
                command.Parameters.AddWithValue("@description", movie.Description);
                command.Parameters.AddWithValue("@public_date", movie.Published);
                command.Parameters.AddWithValue("@image_uri", movie.Uri);
                command.Parameters.AddWithValue("@id", movie.Id);
                conn.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }
    }
}
