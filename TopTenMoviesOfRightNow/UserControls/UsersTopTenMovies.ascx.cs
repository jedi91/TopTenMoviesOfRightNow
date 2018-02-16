using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using TopTenMoviesOfRightNow.TheMovieDB;

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
            List<Movie> selectedMovies = AppSession.Current.SelectedMovies;
            List<Movie> tempList = new List<Movie>();

            foreach (Movie movie in selectedMovies)
            {
                if (movie.Title != title)
                    tempList.Add(movie);
            }

            AppSession.Current.SelectedMovies = tempList;
            rptTopTenMovies.DataSource = tempList;
            rptTopTenMovies.DataBind();
        }
    }
}