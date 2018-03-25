using Newtonsoft.Json;
using System;
using System.Net;

namespace TheMovieDatabase.Search.Movie
{
    public class MovieSearch
    {
        private string response;

        public MovieSearch()
        {           
        }

        public MovieResponse Send(string url)
        {
            using (WebClient client = new WebClient())
            {
                response = client.DownloadString(url);
            }

            return DeserializeResponse();
        }

        private MovieResponse DeserializeResponse()
        {
            try
            {
                return JsonConvert.DeserializeObject<MovieResponse>(response);
            }
            catch (Exception ex)
            {
                return new MovieResponse();
            }
        }
    }
}