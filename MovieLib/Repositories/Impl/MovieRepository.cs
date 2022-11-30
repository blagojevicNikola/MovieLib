using MovieLib.Models;
using MovieLib.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Repositories.Impl
{
    public class MovieRepository : RepositoryBase,IMovieRepository
    {
        public Movie? Create(Movie movie, int adminId, IList<MovieType> types)
        {
            using (var conn = this.GetConnection())
            {
                
                MySqlCommand command = new MySqlCommand();
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();
                command.Connection = conn;
                command.Transaction = transaction;
                command.CommandText = "insert into movie(Title, Director, Description, PublishDate, ImageUri, Admin_Person_id) values(@title,@director,@description,@publish_date,@image_uri,@admin_id)";
                command.Parameters.AddWithValue("@title", movie.Title);
                command.Parameters.AddWithValue("@director", movie.Director);
                command.Parameters.AddWithValue("@description", movie.Description);
                command.Parameters.AddWithValue("@publish_date", movie.Published);
                command.Parameters.AddWithValue("@image_uri", movie.Uri);
                command.Parameters.AddWithValue("@admin_id", adminId);
                MySqlDataReader reader = null ;
                try
                {
                    command.ExecuteNonQuery();
                    var lastInsertedId = command.LastInsertedId;
                    foreach (MovieType t in types)
                    {
                        command.Parameters.Clear();
                        command.CommandText = "insert into movie_of_type values(@type_id, @movie_id)";
                        command.Parameters.AddWithValue("@movie_id", lastInsertedId);
                        command.Parameters.AddWithValue("@type_id", t.Id);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    command.Parameters.Clear();
                    command.CommandText = "select * from movie_info where id=@id";
                    command.Parameters.AddWithValue("@id", lastInsertedId);
                    Debug.WriteLine("Ispis... i lastInsertedId={0}", lastInsertedId);
                    reader = command.ExecuteReader();
                    Movie? result = null;
                    if (reader.Read())
                    {
                        DateTime? published = null;
                        string? uri = null;
                        if (!reader.IsDBNull(4))
                        {
                            published = reader.GetDateTime(4);
                        }
                        if (!reader.IsDBNull(5))
                        {
                            uri = reader.GetString(5);
                        }
                        result = new Movie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), published, uri, reader.GetDecimal(6));
                    }
                    reader.Close();
                    return result;
                }catch(MySqlException e)
                {
                    if(reader != null)
                    {
                        reader.Close();
                    }
                    transaction.Rollback();
                    throw e;
                }
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
                    DateTime? published = null;
                    string? uri = null;
                    if(!reader.IsDBNull(4))
                    {
                        published = reader.GetDateTime(4);
                    }
                    if(!reader.IsDBNull(5))
                    {
                        uri = reader.GetString(5);
                    }
                    result.Add(new Movie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), published, uri, reader.GetDecimal(6)));
                }
                return result;
            }
        }

        public IEnumerable<Movie> GetAllOutsidePlaylist(int userId)
        {
            using (var conn = this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "select * from movie_info m left outer join user_has_in_playlist u on m.id=u.Movie_id where User_Person_id<>@user_id or User_Person_id is null";
                command.Parameters.AddWithValue("@user_id", userId);
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                ObservableCollection<Movie> result = new ObservableCollection<Movie>();
                while (reader.Read())
                {
                    DateTime? published = null;
                    string? uri = null;
                    if (!reader.IsDBNull(4))
                    {
                        published = reader.GetDateTime(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        uri = reader.GetString(5);
                    }
                    result.Add(new Movie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), published, uri, reader.GetDecimal(6)));
                }
                return result;
            }
        }

        public IEnumerable<Movie> GetAllInPlaylist(int userId)
        {
            using (var conn = this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "select * from movie_info m left outer join user_has_in_playlist u on m.id=u.Movie_id where User_Person_id=@user_id";
                command.Parameters.AddWithValue("@user_id", userId);
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                ObservableCollection<Movie> result = new ObservableCollection<Movie>();
                while (reader.Read())
                {
                    DateTime? published = null;
                    string? uri = null;
                    if (!reader.IsDBNull(4))
                    {
                        published = reader.GetDateTime(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        uri = reader.GetString(5);
                    }
                    result.Add(new Movie(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), published, uri, reader.GetDecimal(6)));
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

        public bool Update(Movie movie, IList<MovieType> types)
        {
            using (var conn = this.GetConnection())
            {

                MySqlCommand command = new MySqlCommand();
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();
                command.Connection = conn;
                command.Transaction = transaction;
                command.CommandText = "update movie set Title=@title, Director=@director, Description=@description, PublishDate=@publish_date, ImageUri=@image_uri where id=@id";
                command.Parameters.AddWithValue("@id", movie.Id);
                command.Parameters.AddWithValue("@title", movie.Title);
                command.Parameters.AddWithValue("@director", movie.Director);
                command.Parameters.AddWithValue("@description", movie.Description);
                command.Parameters.AddWithValue("@publish_date", movie.Published);
                command.Parameters.AddWithValue("@image_uri", movie.Uri);
                MySqlDataReader reader = null;
                try
                {
                    command.ExecuteNonQuery();
                    var lastInsertedId = movie.Id;
                    command.Parameters.Clear();
                    command.CommandText = "delete from movie_of_type where Movie_id=@movieId";
                    command.Parameters.AddWithValue("@movieId", lastInsertedId);
                    command.ExecuteNonQuery();
                    foreach (MovieType t in types)
                    {
                        command.Parameters.Clear();
                        command.CommandText = "insert into movie_of_type values(@type_id, @movie_id)";
                        command.Parameters.AddWithValue("@movie_id", lastInsertedId);
                        command.Parameters.AddWithValue("@type_id", t.Id);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                    return true;
                }
                catch (MySqlException e)
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                    transaction.Rollback();
                    throw e;
                }
            }
        }
    }
}
