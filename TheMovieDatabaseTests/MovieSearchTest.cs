using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheMovieDatabase.Search.Movie;

namespace TheMovieDatabaseTests
{
    [TestClass]
    public class MovieSearchTest
    {
        private string apiKey = "############################";
        private string validQuery = "Star Wars";

        [TestMethod]
        public void MovieSearch_CurrentPage()
        {
            MovieRequest request = new MovieRequest(apiKey, validQuery);
            MovieSearch search = new MovieSearch(request);
            MovieResponse response = search.CurrentPage();

            Assert.AreEqual(1, response.page);         
        }

        [TestMethod]
        public void MovieSearch_NextPage()
        {
            MovieRequest request = new MovieRequest(apiKey, validQuery);
            MovieSearch search = new MovieSearch(request);
            MovieResponse response = search.NextPage();

            Assert.AreEqual(2, response.page);
        }

        [TestMethod]
        public void MovieSearch_PreviousPage()
        {
            MovieRequest request = new MovieRequest(apiKey, validQuery);
            MovieSearch search = new MovieSearch(request);
            search.NextPage(); //page 2
            search.NextPage(); //page 3          
            MovieResponse response = search.PreviousPage(); //page 2

            Assert.AreEqual(2, response.page);
        }
    }
}
