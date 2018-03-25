namespace TopTenMoviesOfRightNow.UserControls
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;

    using TheMovieDatabase.Search.Movie;

    public partial class MovieSearch : System.Web.UI.UserControl
    {
        public event EventHandler AddMoviesToList;

        private List<Movie> currentSearchPage;

        public List<Movie> SelectedMovies
        {
            get
            {
                List<Movie> selectedMovies = AppSession.Current.SelectedMovies;
                currentSearchPage = CurrentSearch.CurrentPage().ResultList;

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

        private TheMovieDatabase.Search.Movie.MovieSearch CurrentSearch
        {
            get
            {
                return AppSession.Current.CurrentSearch;
            }
            set
            {
                AppSession.Current.CurrentSearch = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                Search();
                movieSearchResults.Visible = true;
                btnPrevious.Visible = false;
                btnNext.Visible = true;
                btnAddToList.Visible = true;
            }
        }

        private void Search()
        {
            MovieRequest request = new MovieRequest();
            request.ApiKey = AppSettings.MovieDatabaseApiKey;
            request.Query = txbMovieSearch.Text;

            CurrentSearch = new TheMovieDatabase.Search.Movie.MovieSearch(request);
            currentSearchPage = CurrentSearch.CurrentPage().ResultList;
            LoadPage();
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            currentSearchPage = CurrentSearch.PreviousPage().ResultList;
            LoadPage();

            if (CurrentSearch.CurrentPage().page == 1)
            {
                btnPrevious.Visible = false;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            currentSearchPage = CurrentSearch.NextPage().ResultList;
            LoadPage();

            if (CurrentSearch.CurrentPage().page > 1)
            {
                btnPrevious.Visible = true;
            }
        }

        private void LoadPage()
        {
            movieSearchResults.DataSource = currentSearchPage;
            movieSearchResults.DataBind();
        }

        protected void btnAddToList_Click(object sender, EventArgs e)
        {
            AddMoviesToList(sender, e);
        }
    }
}