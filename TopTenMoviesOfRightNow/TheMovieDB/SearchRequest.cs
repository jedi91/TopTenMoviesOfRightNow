using System;
using System.Net;
using Newtonsoft.Json;

using TopTenMoviesOfRightNow.TheMovieDB.ApiResponse;

namespace TopTenMoviesOfRightNow.TheMovieDB
{
    public class SearchRequest
    {
        private string response;

        public SearchRequest(string url)
        {
            using (WebClient client = new WebClient())
            {
                response = client.DownloadString(url);
            }
        }

        public SearchResponse Response
        {
            get
            {
                return DeserializeResponse();
            }
        }

        private SearchResponse DeserializeResponse()
        {
            try
            {
                return JsonConvert.DeserializeObject<SearchResponse>(response);
            }
            catch (Exception ex)
            {
                return new SearchResponse();
            }
        }
    }
}