using MovieLib.Models;
using MovieLib.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Repositories.Impl
{
    public class ReviewRepository : RepositoryBase, IReviewRepository
    {
        public Review? AddReview(Review review, int userId, int movieId)
        {
            using (var conn = this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "insert into user_reviews_movie values(@movieId, @userId, @rate, @comment, @date)";
                command.Parameters.AddWithValue("@movieId", movieId);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@rate", decimal.Parse(review.Rate));
                command.Parameters.AddWithValue("@comment", review.Comment);
                command.Parameters.AddWithValue("@date", DateTime.ParseExact(review.PostDate, "dd/MM/yyyy", null));
                conn.Open();
                command.ExecuteNonQuery();
                command.CommandText = "select * from review_info where Movie_id=@movieId and User_Person_id=@userId";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@movieId", movieId);
                command.Parameters.AddWithValue("@userId", userId);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string? comment = null;
                    if (!reader.IsDBNull(2))
                    {
                        comment = reader.GetString(2);
                    }
                    return new Review(reader.GetString(1), reader.GetDateTime(3), comment, reader.GetDecimal(4));
                }
                return null;
            }
        }

        public IEnumerable<Review> GetAll(int movieId)
        {
            using (var conn = this.GetConnection())
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = conn;
                command.CommandText = "select * from review_info where Movie_id=@movieId";
                command.Parameters.AddWithValue("@movieId", movieId);
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                ObservableCollection<Review> result = new ObservableCollection<Review>();
                while (reader.Read())
                {
                    string? comment = null;
                    if(!reader.IsDBNull(2))
                    {
                        comment = reader.GetString(2);
                    }
                    result.Add(new Review(reader.GetString(1), reader.GetDateTime(3), comment, reader.GetDecimal(4)));
                }
                return result;
            }
        }
    }
}
