using System;
using System.Collections.Generic;
using System.Net;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

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
            SearchResponse apiResponse = GetApiResponse();

            List<Movie> movieList = new List<Movie>();
            foreach (Result result in apiResponse.results)
            {
                Movie movie = new Movie(result);
                movieList.Add(movie);
            }

            return movieList;
        }

        private SearchResponse GetApiResponse()
        {
            string response = GetResponseString();

            try
            {
                SearchResponse apiResponse = JsonConvert.DeserializeObject<SearchResponse>(response);
                return apiResponse;
            }
            catch (Exception ex)
            {
                //WIP
                //Next Step: Retrieve the ErrorResponse and pass it/redirect to error page.
                return null;
            }
        }

        private string GetResponseString()
        {
            string response;
            using (WebClient client = new WebClient())
            {
                response = client.DownloadString(requestUrl);
            }
            return response;
        }
    }
}