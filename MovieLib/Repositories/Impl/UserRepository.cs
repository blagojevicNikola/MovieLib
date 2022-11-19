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
    public class UserRepository : RepositoryBase, IUserRepository
    {
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
                    result.Add(new User(reader.GetInt32(0), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetBoolean(5), reader.GetString(6), reader.GetString(7)));
                }
                return result;
            }
        }
    }
}
