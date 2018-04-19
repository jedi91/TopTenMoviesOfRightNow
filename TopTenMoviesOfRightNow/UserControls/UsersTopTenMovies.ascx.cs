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