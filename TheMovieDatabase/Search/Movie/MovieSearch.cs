using Newtonsoft.Json;
using System;
using System.Net;

namespace TheMovieDatabase.Search.Movie
{
    public class MovieSearch
    {
        private string responseString;
        private MovieRequest request;
        private MovieResponse response;

        public MovieSearch(MovieRequest request)
        {
            this.request = request;
            DownloadResponse();
        }

        public MovieResponse CurrentPage()
        {
            return response;
        }

        public MovieResponse NextPage()
        {
            if (request.Page < response.total_pages)
            {
                request.Page++;
            }

            DownloadResponse();
            return response;
        }

        public MovieResponse PreviousPage()
        {
            if (request.Page > 1)
            {
                request.Page--;
            }

            DownloadResponse();
            return response;
        }

        private void DownloadResponse()
        {
            using (WebClient client = new WebClient())
            {
                responseString = client.DownloadString(request.RequestUrl());
            }

            DeserializeResponse();
        }

        private void DeserializeResponse()
        {
            try
            {
                response = JsonConvert.DeserializeObject<MovieResponse>(responseString);
            }
            catch (Exception ex)
            {
                response = new MovieResponse();
            }
        }
    }
}