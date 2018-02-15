using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using Newtonsoft.Json;

using TopTenMoviesOfRightNow.TheMovieDB.ApiResponse;

namespace TopTenMoviesOfRightNow.TheMovieDB
{
    public class MovieDB
    {
        public List<Movie> GetPage(string query, int page)
        {
            SearchResponse apiResponse = GetApiResponse(query, page);

            List<Movie> movieList = new List<Movie>();
            foreach (Result result in apiResponse.results)
            {
                Movie movie = new Movie(result);
                movieList.Add(movie);
            }

            return movieList;
        }

        private SearchResponse GetApiResponse(string query, int page)
        {
            string requestUrl = CreateRequestUrl(query, page);
            string response = GetResponseString(requestUrl);

            try
            {
                SearchResponse apiResponse = JsonConvert.DeserializeObject<SearchResponse>(response);
                return apiResponse;
            }
            catch(Exception ex)
            {
                //WIP
                //Next Step: Retrieve the ErrorResponse and pass it/redirect to error page.
                return null;
            }
        }

        private string CreateRequestUrl(string query, int page)
        {
            query = HttpUtility.UrlEncode(query);
            string requestUrl = string.Format("{0}{1}&language=en-US&query={2}&page={3}&include_adult=false", 
                                                AppSettings.SearchUrl, AppSettings.MovieDatabaseApiKey, query, page.ToString());
            return requestUrl;
        }

        private string GetResponseString(string requestUrl)
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