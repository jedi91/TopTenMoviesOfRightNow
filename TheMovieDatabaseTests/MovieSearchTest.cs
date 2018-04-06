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

        #region Page Number Validation Tests

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

        [TestMethod]
        public void MovieSearch_GetLastPage()
        {
            MovieRequest request = new MovieRequest(apiKey, validQuery);
            MovieResponse lastPageResponse = GetLastPageResposne(request);

            Assert.AreEqual(lastPageResponse.total_pages, lastPageResponse.page);
        }

        [TestMethod]
        public void MovieSearch_NextPageFromLastPage()
        {
            MovieRequest request = new MovieRequest(apiKey, validQuery);
            MovieSearch lastPageSearch = GetLastPageSearch(request);

            MovieResponse nextOnLastResponse = lastPageSearch.NextPage();

            Assert.AreEqual(nextOnLastResponse.total_pages, nextOnLastResponse.page);
        }

        [TestMethod]
        public void MovieSearch_PreviousPageFromFirstPage()
        {
            MovieRequest request = new MovieRequest(apiKey, validQuery);
            MovieSearch search = new MovieSearch(request);
            MovieResponse response = search.PreviousPage();

            Assert.AreEqual(1, response.page);
        }

        [TestMethod]
        public void MovieSearch_LoopUntilLastPage()
        {
            MovieRequest request = new MovieRequest(apiKey, validQuery);
            MovieSearch search = new MovieSearch(request);
            MovieResponse response = search.CurrentPage();

            for(int page = 1; page <= response.total_pages; page++)
            {
                request.Page = page;
                MovieSearch pageSearch = new MovieSearch(request);
                MovieResponse pageResponse = pageSearch.CurrentPage();

                Assert.AreEqual(page, pageResponse.page);
            }
        }

        [TestMethod]
        public void MovieSearch_LoopUntilLastPageWithNextPage()
        {
            MovieRequest request = new MovieRequest(apiKey, validQuery);
            MovieSearch search = new MovieSearch(request);
            MovieResponse response = search.CurrentPage();

            for (int page = 2; page <= response.total_pages; page++)
            {
                MovieResponse pageResponse = search.NextPage();

                Assert.AreEqual(page, pageResponse.page);
            }
        }

        [TestMethod]
        public void MovieSearch_LoopFromLastPage()
        {
            MovieRequest request = new MovieRequest(apiKey, validQuery);
            MovieSearch search = new MovieSearch(request);
            MovieResponse response = search.CurrentPage();

            for (int page = response.total_pages; page > 0; page--)
            {
                request.Page = page;

                MovieSearch pageSearch = new MovieSearch(request);
                MovieResponse pageResponse = pageSearch.CurrentPage();

                Assert.AreEqual(page, pageResponse.page);
            }
        }

        [TestMethod]
        public void MovieSearch_LoopFromLastPageWithPrevious()
        {
            MovieRequest request = new MovieRequest(apiKey, validQuery);
            MovieSearch search = GetLastPageSearch(request);
            MovieResponse response = search.CurrentPage();

            for(int page = response.total_pages - 1; page > 0; page--)
            {
                MovieResponse previousPage = search.PreviousPage();

                Assert.AreEqual(page, previousPage.page);
            }
        }

        #endregion Page Number Validation Tests

        #region Helper Methods

        private MovieResponse GetLastPageResposne(MovieRequest request)
        {
            MovieSearch lastPageSearch = GetLastPageSearch(request);
            return lastPageSearch.CurrentPage();
        }

        private MovieSearch GetLastPageSearch(MovieRequest request)
        {
            MovieSearch currentSearch = new MovieSearch(request);
            MovieResponse currentResponse = currentSearch.CurrentPage();

            request.Page = currentResponse.total_pages;

            return new MovieSearch(request);
        }

        #endregion HelperMethods
    }
}
