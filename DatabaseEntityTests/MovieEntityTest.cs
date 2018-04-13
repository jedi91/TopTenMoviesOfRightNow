using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseEntities;

namespace DatabaseEntityTests
{
    [TestClass]
    public class MovieEntityTest
    {
        [TestMethod]
        public void MovieEntity_AddMovie()
        {
            string movieTitle = string.Format("Test Movie {0}", DateTime.Now);
            DateTime movieReleaseDate = DateTime.Parse("5-25-1977");

            MovieEntity movie = new MovieEntity();
            movie.Title = movieTitle;
            movie.ReleaseDate = movieReleaseDate;
            movie.RankingWeight = 10;
            movie.LastRankedTime = DateTime.Now;

            MovieCollection movieCol = new MovieCollection();
            movieCol.Add(movie);
            movieCol.Save();

            MovieCollection movieSearchCol = new MovieCollection();
            movieSearchCol.Fetch("Title", movieTitle);

            bool foundEntities = movieCol.Count > 0;

            Assert.AreEqual(true, foundEntities);
            Assert.AreEqual(movieTitle, movieCol[0].Title);
            Assert.AreEqual(movieReleaseDate, movieCol[0].ReleaseDate);
        }

        [TestMethod]
        public void MovieEntity_FetchMovie()
        {
            MovieCollection movieCol = new MovieCollection();
            movieCol.Fetch("Title", "Star Wars");

            bool foundEntities = movieCol.Count > 0;

            Assert.AreEqual(true, foundEntities);
            Assert.AreEqual("Star Wars", movieCol[0].Title);
            Assert.AreEqual(DateTime.Parse("1977-05-25"), movieCol[0].ReleaseDate);
        }
    }
}
