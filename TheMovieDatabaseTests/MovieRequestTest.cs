using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheMovieDatabase.Search.Movie;

namespace TheMovieDatabaseTests
{
    [TestClass]
    public class MovieRequestTest
    {
        private string baseUrl = "https://api.themoviedb.org/3/search/movie";
        private string validQuery = "Star Wars";
        private string apiKey = "############################";

        [TestMethod]
        public void RequestUrl_RequiredFieldsOnly()
        {
            MovieRequest request = new MovieRequest(apiKey, validQuery);

            string requestUrl = request.Url();
            string validUrl = string.Format("{0}?api_key={1}&query={2}",
               baseUrl, apiKey, validQuery);

            Assert.AreEqual(validUrl, requestUrl);
        }

        [TestMethod]
        public void RequestUrl_Pages()
        {
            MovieRequest request = new MovieRequest(apiKey, validQuery);
            
            for(int page = 1; page < 11; page++)
            {
                request.Page = page;
                string requestUrl = request.Url();
                string validUrl = string.Format("{0}?api_key={1}&query={2}&page={3}",
                   baseUrl, apiKey, validQuery, page);

                Assert.AreEqual(validUrl, requestUrl);
            } 
        }

        [TestMethod]
        public void RequestUrl_Spanish()
        {
            MovieRequest request = new MovieRequest(apiKey, validQuery);
            request.Language = "es";

            string requestUrl = request.Url();
            string validUrl = string.Format("{0}?api_key={1}&query={2}&language={3}",
              baseUrl, apiKey, validQuery,  "es");

            Assert.AreEqual(validUrl, requestUrl);
        }

        [TestMethod]
        public void RequestUrl_IncludeAdult()
        {
            MovieRequest request = new MovieRequest(apiKey, validQuery);
            request.IncludeAdult = false;

            string requestUrl = request.Url();
            string validUrl = string.Format("{0}?api_key={1}&query={2}&include_adult={3}",
              baseUrl, apiKey, validQuery, false);

            Assert.AreEqual(validUrl, requestUrl);
        }

        [TestMethod]
        public void RequestUrl_PrimaryReleaseYears()
        {
            MovieRequest request = new MovieRequest(apiKey, validQuery);

            for(int year = 1910; year < 2019; year++)
            {
                request.PrimaryReleaseYear = year;

                string requestUrl = request.Url();
                string validUrl = string.Format("{0}?api_key={1}&query={2}&primary_release_year={3}",
                  baseUrl, apiKey, validQuery, year);

                Assert.AreEqual(validUrl, requestUrl);
            }
        }

        [TestMethod]
        public void RequestUrl_Years()
        {
            MovieRequest request = new MovieRequest(apiKey, validQuery);

            for (int year = 1910; year < 2019; year++)
            {
                request.Year = year;

                string requestUrl = request.Url();
                string validUrl = string.Format("{0}?api_key={1}&query={2}&year={3}",
                  baseUrl, apiKey, validQuery, year);

                Assert.AreEqual(validUrl, requestUrl);
            }
        }

        [TestMethod]
        public void RequestUrl_US()
        {
            MovieRequest request = new MovieRequest(apiKey, validQuery);
            request.Region = "US";

            string requestUrl = request.Url();
            string validUrl = string.Format("{0}?api_key={1}&query={2}&region={3}",
              baseUrl, apiKey, validQuery, "US");

            Assert.AreEqual(validUrl, requestUrl);
        }
    }
}
