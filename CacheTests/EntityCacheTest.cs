using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseEntities;
using AppCache;

namespace AppCacheTests
{
    [TestClass]
    public class EntityCacheTest
    {
        [TestMethod]
        public void EntityCache_GetMovie()
        {
            Movie testMovie = EntityCache.GetMovie(1);

            Assert.IsNotNull(testMovie);
            Assert.AreEqual(1, testMovie.MovieId);
            Assert.AreEqual("Star Wars", testMovie.Title);
            Assert.AreEqual(DateTime.Parse("1977-05-25"), testMovie.ReleaseDate);
        }

        [TestMethod]
        public void EntityCache_GetMovie_InvalidMovieId()
        {
            Movie testMovie = EntityCache.GetMovie(88888888);

            Assert.IsNull(testMovie);
        }

        [TestMethod]
        public void EntityCache_GetMovieByTitleAndRelease_Success()
        {
            Movie testMovie = EntityCache.GetMovieByTitleAndRelease("Star Wars", DateTime.Parse("5-25-1977"));

            Assert.IsNotNull(testMovie);
            Assert.AreEqual(1, testMovie.MovieId);
            Assert.AreEqual("Star Wars", testMovie.Title);
            Assert.AreEqual(DateTime.Parse("1977-05-25"), testMovie.ReleaseDate);
        }
    }
}
