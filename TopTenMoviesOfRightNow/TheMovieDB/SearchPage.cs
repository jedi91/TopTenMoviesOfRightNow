using System.Collections.Generic;
using System.Web.UI.WebControls;

using TopTenMoviesOfRightNow.TheMovieDB.ApiResponse;

namespace TopTenMoviesOfRightNow.TheMovieDB
{
    public class SearchPage
    {
        private string requestUrl;
        private List<Movie> searchResults;

        public SearchPage(string query, int pageNumber)
        {
            searchResults = new List<Movie>();

            requestUrl = string.Format("{0}?api_key={1}&language=en-US&query={2}&page={3}&include_adult=false",
                AppSettings.SearchUrl, AppSettings.MovieDatabaseApiKey, query, pageNumber.ToString());
        }

        public void Load(Repeater resultsRepeater)
        {
            searchResults = GetSearchResults(); 
            AppSession.Current.CurrentSearchPage = searchResults;
            resultsRepeater.DataSource = searchResults;
            resultsRepeater.DataBind();
        }

        private List<Movie> GetSearchResults()
        {
            SearchRequest request = new SearchRequest(requestUrl);

            List<Movie> movieList = new List<Movie>();
            foreach (Result result in request.Response.results)
            {
                Movie movie = new Movie(result);
                movieList.Add(movie);
            }

            return movieList;
        }
    }
}