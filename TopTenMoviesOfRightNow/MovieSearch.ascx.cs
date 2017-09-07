using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TopTenMoviesOfRightNow.TheMovieDB;

namespace TopTenMoviesOfRightNow
{
    public partial class MovieSearch : System.Web.UI.UserControl
    {
        private int CurrentPageNumber
        {
            get { return (int)Session["currentPage"]; }
            set { Session["currentPage"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentPageNumber = 1;
                movieSearchResults.Visible = false;
                btnPrevious.Visible = false;
                btnNext.Visible = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadSearchResults();
            movieSearchResults.Visible = true;
            btnNext.Visible = true;
            CurrentPageNumber = 1;
        }

        private void LoadSearchResults()
        {
            MovieDB movieDBApi = new MovieDB();
            movieSearchResults.DataSource = movieDBApi.Search(txbMovieSearch.Text);
            movieSearchResults.DataBind();
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            CurrentPageNumber = CurrentPageNumber - 1;
            LoadPage(CurrentPageNumber);

            if (CurrentPageNumber == 1)
            {
                btnPrevious.Visible = false;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            CurrentPageNumber = CurrentPageNumber + 1;
            LoadPage(CurrentPageNumber);

            if (CurrentPageNumber > 1)
            {
                btnPrevious.Visible = true;
            }
        }

        private void LoadPage(int page)
        {
            MovieDB movieDBApi = new MovieDB();
            movieSearchResults.DataSource = movieDBApi.GetPage(txbMovieSearch.Text, page);
            movieSearchResults.DataBind();
        }
    }
}