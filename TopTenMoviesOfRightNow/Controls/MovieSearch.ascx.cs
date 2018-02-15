namespace TopTenMoviesOfRightNow.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;

    using TheMovieDB;

    public partial class MovieSearch : System.Web.UI.UserControl
    {
        public event EventHandler AddMoviesToList;

        public List<Movie> SelectedMovies
        {
            get
            {
                List<Movie> selectedMovies = AppSession.Current.SelectedMovies;

                List<Movie> currentSearchPage = AppSession.Current.CurrentSearchPage;
                foreach (RepeaterItem item in movieSearchResults.Items)
                {
                    CheckBox checkBox = (CheckBox)item.FindControl("ckbChooseMovie");
                    if (checkBox.Checked && !selectedMovies.Contains(currentSearchPage[item.ItemIndex]))
                    {
                        selectedMovies.Add(currentSearchPage[item.ItemIndex]);
                    }
                }

                return selectedMovies;
            }
        }

        private int CurrentPageNumber
        {
            get { return AppSession.Current.CurrentPage; }
            set { AppSession.Current.CurrentPage = value; }
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
            AppSession.Current.CurrentSearchPage = currentPage;
            movieSearchResults.DataSource = currentPage;
            movieSearchResults.DataBind();
        }

        protected void btnAddToList_Click(object sender, EventArgs e)
        {
            AddMoviesToList(sender, e);
        }
    }
}