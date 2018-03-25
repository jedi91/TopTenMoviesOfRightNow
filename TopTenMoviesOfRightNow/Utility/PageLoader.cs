using System.Collections.Generic;
using System.Web.UI.WebControls;

using TheMovieDatabase.Search.Movie;

namespace TopTenMoviesOfRightNow.TheMovieDB
{
    public class PageLoader
    {
        private string requestUrl;    
        private MovieSearch search;

        public PageLoader(string query, int pageNumber)
        {
            search = new MovieSearch();
            requestUrl = string.Format("{0}?api_key={1}&language=en-US&query={2}&page={3}&include_adult=false",
                AppSettings.SearchUrl, AppSettings.MovieDatabaseApiKey, query, pageNumber.ToString());
        }

        public void Load(Repeater resultsRepeater)
        {
            List<Movie> searchResults = GetSearchResults(); 
            AppSession.Current.CurrentSearchPage = searchResults;
            resultsRepeater.DataSource = searchResults;
            resultsRepeater.DataBind();
        }

        private List<Movie> GetSearchResults()
        {
            MovieResponse response = search.Send(requestUrl);
            return response.ResultList;
        }
    }
}