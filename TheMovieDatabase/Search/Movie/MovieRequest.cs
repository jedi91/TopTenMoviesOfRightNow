namespace TheMovieDatabase.Search.Movie
{
    public class MovieRequest
    {
        int page = 1;
        private string apiKey;
        private string query;
        private string baseUrl = "https://api.themoviedb.org/3/search/movie";

        public int? Year { get; set; }
        public int? PrimaryReleaseYear { get; set; }
        public bool? IncludeAdult { get; set; }
        public string Region { get; set; }
        public string Language { get; set; }

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

        public MovieRequest(string apiKey, string query)
        {
            this.apiKey = apiKey;
            this.query = query;
        }

        public string Url()
        {
            string requestUrl = string.Format("{0}?api_key={1}&query={2}",
                baseUrl, apiKey, query);

            if (page != 1)
            {
                requestUrl = string.Format("{0}&page={1}", requestUrl, page);
            }

            if (IncludeAdult != null)
            {
                requestUrl = string.Format("{0}&include_adult={1}", requestUrl, IncludeAdult);
            } 

            if(!string.IsNullOrEmpty(Language))
            {
                requestUrl = string.Format("{0}&language={1}", requestUrl, Language);
            }

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
