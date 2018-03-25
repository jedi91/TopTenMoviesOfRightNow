namespace TopTenMoviesOfRightNow.UserControls
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;

    using TheMovieDB;
    using TheMovieDatabase.Search.Movie;

    public partial class MovieSearch : System.Web.UI.UserControl
    {
        public event EventHandler AddMoviesToList;

        private PageLoader currentPage;

        public List<Movie> SelectedMovies
        {
            get
            {
                List<Movie> selectedMovies = AppSession.Current.SelectedMovies;

                foreach (RepeaterItem item in movieSearchResults.Items)
                {
                    CheckBox checkBox = (CheckBox)item.FindControl("ckbChooseMovie");
                    if (checkBox.Checked && !selectedMovies.Contains(CurrentSearchPage[item.ItemIndex]))
                    {
                        selectedMovies.Add(CurrentSearchPage[item.ItemIndex]);
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

        private List<Movie> CurrentSearchPage
        {
            get { return AppSession.Current.CurrentSearchPage; }
            set { AppSession.Current.CurrentSearchPage = value; }
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
            currentPage = new PageLoader(txbMovieSearch.Text, page);
            currentPage.Load(movieSearchResults);
        }

        protected void btnAddToList_Click(object sender, EventArgs e)
        {
            AddMoviesToList(sender, e);
        }
    }
}