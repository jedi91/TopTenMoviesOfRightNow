using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using TopTenMoviesOfRightNow.TheMovieDB;

namespace TopTenMoviesOfRightNow.Controls
{
    public partial class MovieSearch : System.Web.UI.UserControl
    {
        public event EventHandler AddMoviesToList;

        public List<Movie> SelectedMovies
        {
            get
            {
                List<Movie> selectedMovies = new List<Movie>();
                if (Session["SelectedMovies"] != null)
                {
                    selectedMovies = (List<Movie>)Session["SelectedMovies"];            
                }

                List<Movie> currentPage = (List<Movie>)Session["CurrentPageList"];
                foreach (RepeaterItem item in movieSearchResults.Items)
                {
                    CheckBox checkBox = (CheckBox)item.FindControl("ckbChooseMovie");
                    if (checkBox.Checked)
                    {
                        if(!selectedMovies.Contains(currentPage[item.ItemIndex]))
                            selectedMovies.Add(currentPage[item.ItemIndex]);
                    }
                }

                Session["SelectedMovies"] = selectedMovies;

                return selectedMovies;
            }
        }

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
                btnAddToList.Visible = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbMovieSearch.Text))
            {
                LoadPage(1);
                movieSearchResults.Visible = true;
                btnPrevious.Visible = false;
                btnNext.Visible = true;
                btnAddToList.Visible = true;
                CurrentPageNumber = 1;
            }
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
            List<Movie> currentPage = movieDBApi.GetPage(txbMovieSearch.Text, page);
            Session["CurrentPageList"] = currentPage;
            movieSearchResults.DataSource = currentPage;
            movieSearchResults.DataBind();
        }

        protected void btnAddToList_Click(object sender, EventArgs e)
        {
            AddMoviesToList(sender, e);
        }
    }
}