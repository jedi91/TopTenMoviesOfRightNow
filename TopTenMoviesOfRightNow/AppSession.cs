using System.Collections.Generic;
using System.Web;

using TheMovieDatabase.Search.Movie;

namespace TopTenMoviesOfRightNow
{
    public class AppSession
    {
        private int currentPage;
        private List<Movie> selectedMovies;
        private List<Movie> currentSearchPage;

        private AppSession()
        {
            currentPage = 1;
            selectedMovies = new List<Movie>();
            currentSearchPage = new List<Movie>();
        }

        public static AppSession Current
        {
            get
            {
                AppSession session = (AppSession)HttpContext.Current.Session["__AppSession__"];
                if (session == null)
                {
                    session = new AppSession();
                    HttpContext.Current.Session["__AppSession__"] = session;
                }

                return session;
            }
        }

        public int CurrentPage
        {
            get
            {
                return currentPage;
            }

            set
            {
                currentPage = value;
            }
        }

        public List<Movie> SelectedMovies
        {
            get
            {
                return selectedMovies;
            }

            set
            {
                selectedMovies = value;
            }
        }

        public List<Movie> CurrentSearchPage
        {
            get
            {
                return currentSearchPage;
            }

            set
            {
                currentSearchPage = value;
            }
        }
    }
}