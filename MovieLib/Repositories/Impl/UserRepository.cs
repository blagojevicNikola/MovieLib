using MovieLib.Models;
using MovieLib.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieLib.Repositories.Impl
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public bool AddMovieToPlaylist(Movie movie, User user)
        {
            using (var conn = this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "insert into user_has_in_playlist values(@user_id, @movie_id)";
                command.Parameters.AddWithValue("@movie_id", movie.Id);
                command.Parameters.AddWithValue("@user_id", user.Id);
                conn.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public bool BlockUser(int id)
        {
            using (var conn = this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "update user set Blocked=true where Person_id=@id";
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public IEnumerable<User> GetAll()
        {
            using(var conn = this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "select * from user_info";
                conn.Open();
                ObservableCollection<User> result = new ObservableCollection<User>();
                MySqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    result.Add(new User(reader.GetInt32(0), reader.GetString(3), reader.GetString(4), reader.GetString(1), reader.GetBoolean(5), reader.GetString(6), reader.GetString(7)));
                }
                return result;
            }
        }

        public bool RemoveMovieFromPlaylist(int movieId, int userId)
        {
            using (var conn = this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "delete from user_has_in_playlist where User_Person_id=@user_id and Movie_id=@movie_id";
                command.Parameters.AddWithValue("@movie_id", movieId);
                command.Parameters.AddWithValue("@user_id", userId);
                conn.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public bool UnblockUser(int id)
        {
            using (var conn = this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "update user set Blocked=false where Person_id=@id";
                command.Parameters.AddWithValue("@id", id);
                conn.Open();
                command.ExecuteNonQuery();
                return true;
            }
        }

        public void UpdateLanguage(int languageId, int personId)
        {
            using(var conn=this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "update person set Language_id=@languageId where id=@id";
                command.Parameters.AddWithValue("@id", personId);
                command.Parameters.AddWithValue("@languageId", languageId);
                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateTheme(int themeId, int personId)
        {
            using (var conn = this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "update person set Theme_id=@themeId where id=@id";
                command.Parameters.AddWithValue("@id", personId);
                command.Parameters.AddWithValue("@themeId", themeId);
                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
