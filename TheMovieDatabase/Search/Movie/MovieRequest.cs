using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovieDatabase.Search.Movie
{
    public class MovieRequest
    {
        private int page = 1;
        private bool includeAdult = false;
        private string language = "en-US";
        private string baseUrl = "https://api.themoviedb.org/3/search/movie";

        public int? Year { get; set; }
        public int? PrimaryReleaseYear { get; set; }
        public string ApiKey { get; set; }
        public string Query { get; set; }
        public string Region { get; set; }

        public string Language
        {
            get
            {
                return language;
            }
            set
            {
                language = value;
            }
        }

        public int Page
        {
            get
            {
                return page;
            }
            set
            {
                page = value;
            }
        }

        public bool IncludeAdult
        {
            get
            {
                return includeAdult;
            }
            set
            {
                includeAdult = value;
            }
        }

        public string RequestUrl()
        {
            string requestUrl = string.Format("{0}?api_key={1}&language={2}&query={3}&page={4}&include_adult={5}",
                baseUrl, ApiKey, Language, Query, page, includeAdult);

            if (Year != null)
            {
                requestUrl = string.Format("{0}&year={1}", requestUrl, Year);
            }

            if(PrimaryReleaseYear != null)
            {
                requestUrl = string.Format("{0}&primary_release_year={1}", requestUrl, PrimaryReleaseYear);
            }

            if(!string.IsNullOrEmpty(Region))
            {
                requestUrl = string.Format("{0}&region={1}", requestUrl, Region);
            }

            return requestUrl;
        }
    }
}
