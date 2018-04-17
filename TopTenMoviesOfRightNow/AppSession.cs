using System.Collections.Generic;
using System.Web;

using TheMovieDatabase.Search.Movie;

namespace TopTenMoviesOfRightNow
{
    public class AppSession
    {
        private int currentPage;
        private List<MovieResult> selectedMovies;
        private List<MovieResult> currentSearchPage;
        private MovieSearch currentSearch;

        private AppSession()
        {
            currentPage = 1;
            selectedMovies = new List<MovieResult>();
            currentSearchPage = new List<MovieResult>();
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

        public List<MovieResult> SelectedMovies
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

        public MovieSearch CurrentSearch
        {
            get
            {
                return currentSearch;
            }
            set
            {
                currentSearch = value;
            }
        }
    }
}