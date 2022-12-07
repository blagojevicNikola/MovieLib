using MovieLib.Commands;
using MovieLib.Models;
using MovieLib.Repositories.Impl;
using MovieLib.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieLib
{
    public class MoviePageViewModel : BaseViewModel
    {
        private User _user;
        private string _comment;
        public Movie Movie { get; set; }
        public string Comment { get { return _comment; } set { _comment = value; NotifyPropertyChanged("Comment"); } }
        public ICommand BackToMoviesCommand { get; set; }
        public ICommand PostReviewCommand { get; set; }
        public ObservableCollection<Review> Reviews { get; set; }
        public MoviePageViewModel(NavigationStore navigationStore, User user, Movie movie, bool fromPlaylist)
        {
            _user = user;
            if(!fromPlaylist) 
            {
                BackToMoviesCommand = new NavigateCommand<MoviesUserViewModel>(navigationStore, () => new MoviesUserViewModel(navigationStore, user));
            }
            else
            {
                BackToMoviesCommand = new NavigateCommand<PlaylistViewModel>(navigationStore, () => new PlaylistViewModel(navigationStore, user));
            }
            Movie = movie;
            _comment = "";
            IReviewRepository reviewRep = new ReviewRepository();
            Reviews = (ObservableCollection<Review>)reviewRep.GetAll(movie.Id!.Value);
            PostReviewCommand = new RelyCommand(() => postReview());
        }

        public void postReview()
        {
            Review newReview = new Review(_user.Username, DateTime.Now, Comment, new decimal(0.00));
            IReviewRepository reviewRep = new ReviewRepository();
            if(reviewRep.AddReview(newReview, _user.Id!.Value, Movie.Id!.Value) != null)
            {
                Comment = "";
                Reviews.Add(newReview);
            }
        }
    }
}
