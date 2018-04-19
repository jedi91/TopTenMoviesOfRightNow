using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using DatabaseEntities;
using TheMovieDatabase.Search.Movie;

namespace TopTenMoviesOfRightNow.UserControls
{
    public partial class UsersTopTenMovies : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmitTopTen_Click(object sender, EventArgs e)
        {
            //WIP
            //Next step: Add class to interface with AWS DynamoDB.
            //The class will be used to submit the user's top ten
            //and to retrieve the overall top ten, which will be
            //passed to a new control to display the overall top ten.
            //All other controls will be hidden. A resubmit list button
            //will be made available that will allow the user to repeat
            //the process after a certain amount of time has elapsed. 

            foreach(RepeaterItem item in rptTopTenMovies.Items)
            {
                Label title = (Label)item.FindControl("lblTitle");
                Label releaseDate = (Label)item.FindControl("lblReleaseDate");
                Label rank = (Label)item.FindControl("lblRank");

                AddUserRanking(title.Text, DateTime.Parse(releaseDate.Text), int.Parse(rank.Text));
            }
        }

        private void AddUserRanking(string title, DateTime releaseDate, int rank)
        {
            using (TopTenRightNowContext context = new TopTenRightNowContext())
            {
                Movie movie = AppCache.EntityCache.GetMovieByTitleAndRelease(title, releaseDate);
                if (movie == null)
                {
                    movie = new Movie()
                    {
                        Title = title,
                        ReleaseDate = releaseDate,
                        RankingWeight = 11 - rank,
                        LastRankedTime = DateTime.Now
                    };

                    context.Movies.Add(movie);
                }

                UserRanking ranking = new UserRanking()
                {
                    MovieId = movie.MovieId,
                    RankingWeight = 11 - rank,
                    RankedTime = DateTime.Now
                };

                context.UserRankings.Add(ranking);
                context.SaveChanges();
            }
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)button.Parent;
            Label title = (Label)item.FindControl("lblTitle");

            RemoveMovieByTitle(title.Text);  
        }

        private void RemoveMovieByTitle(string title)
        {
            List<MovieResult> selectedMovies = AppSession.Current.SelectedMovies;
            List<MovieResult> tempList = new List<MovieResult>();

            foreach (MovieResult movie in selectedMovies)
            {
                if (movie.title != title)
                    tempList.Add(movie);
            }

            AppSession.Current.SelectedMovies = tempList;
            rptTopTenMovies.DataSource = tempList;
            rptTopTenMovies.DataBind();
        }
    }
}