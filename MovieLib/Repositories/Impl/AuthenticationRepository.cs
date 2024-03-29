﻿using MovieLib.Models;
using MovieLib.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLib.Repositories.Impl
{
    public class AuthenticationRepository : RepositoryBase, IAuthenticationRepository
    {
        public async Task<Admin?> LoginAdmin(string username, string password)
        {
            using(var conn = this.GetConnection()) {
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "select * from admin_info where Username=@username and Password=@password";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                conn.Open();
                var reader = await command.ExecuteReaderAsync();
                if (reader.Read())
                {
                    return new Admin(reader.GetInt32(0), reader.GetString(3), reader.GetString(4), reader.GetString(1), reader.GetString(5), reader.GetString(6));
                }
                return null;
            }
        }

        public async Task<User?> LoginUser(string username, string password)
        {
            using (var conn = this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "select * from user_info where Username=@username and Password=@password and Blocked=false";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                conn.Open();
                var reader = await command.ExecuteReaderAsync();
                if (reader.Read())
                {
                    return new User(reader.GetInt32(0), reader.GetString(3), reader.GetString(4), reader.GetString(1), reader.GetBoolean(5), reader.GetString(6), reader.GetString(7));
                }
                return null;
            }
        }

        public async Task<User?> RegisterUser(User user, string password)
        {
            using (var conn = this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "insert into person(Username, Password, Name, Surname, Theme_id, Language_id) values(@username, @password, @name, @surname, @themeId, @languageId)";
                command.Parameters.AddWithValue("@username", user.Username);
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@surname", user.Surname);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@themeId", 1);
                command.Parameters.AddWithValue("@languageId", 1);
                conn.Open();
                command.ExecuteNonQuery();
                var lastInserted = command.LastInsertedId;
                command.CommandText = "insert into user(Person_id, Blocked) values(@id, @blocked)";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@id", lastInserted);
                command.Parameters.AddWithValue("@blocked", false);
                command.ExecuteNonQuery();
                command.CommandText = "select * from user_info where id=@id";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@id", lastInserted);
                var reader = await command.ExecuteReaderAsync();
                if (reader.Read())
                {
                    return new User(reader.GetInt32(0), reader.GetString(3), reader.GetString(4), reader.GetString(1), reader.GetBoolean(5), reader.GetString(6), reader.GetString(7));
                }
                return null;
            }
        }
    }
}
