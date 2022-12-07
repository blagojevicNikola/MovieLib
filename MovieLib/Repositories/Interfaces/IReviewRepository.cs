using MovieLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Repositories.Interfaces
{
    public interface IReviewRepository
    {
        public IEnumerable<Review> GetAll(int movieId);
        public Review? AddReview(Review review, int userId, int movieId);
    }
}
