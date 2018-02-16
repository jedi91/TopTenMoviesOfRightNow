using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TopTenMoviesOfRightNow
{
    public partial class TopTenMovies : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            movieSearch.AddMoviesToList += MovieSearch_AddMoviesToList;
        }

        private void MovieSearch_AddMoviesToList(object sender, EventArgs e)
        {
            RefreshMovieList();
        }

        private void RefreshMovieList()
        {
            Repeater userTopTen = (Repeater)usersTopTenMovies.FindControl("rptTopTenMovies");
            userTopTen.DataSource = movieSearch.SelectedMovies;
            userTopTen.DataBind();
        }
    }
}