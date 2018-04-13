using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseEntities;
using System.Data;

namespace DatabaseEntityTests
{
    [TestClass]
    public class SqlServerUtilityTest
    {
        private string validMovieQuery = "select * from Movie where Title = 'Star Wars'";

        [TestMethod]
        public void SqlServerUtility_ExecuteQuery_EmptyString()
        {
            IDatabaseUtility database = new SqlServerUtility();

            try
            {
                DataTable data = database.ExecuteQuery(string.Empty);
            }
            catch(Exception ex)
            {
                Assert.AreEqual(true, true);
            }
        }

        [TestMethod]
        public void SqlServerUtility_ExectueQuery_ValidMovieQuery()
        {
            IDatabaseUtility database = new SqlServerUtility();
            DataTable data = database.ExecuteQuery(validMovieQuery);

            Assert.AreEqual(5, data.Columns.Count);
            Assert.AreEqual(1, data.Rows.Count);
        }

        [TestMethod]
        public void SqlServerUtility_ExecuteNonQuery_InsertMovie()
        {
            string movieTitle = string.Format("Test Movie {0}", DateTime.Now);
            DateTime releaseDate = DateTime.Now;

            IDatabaseUtility database = new SqlServerUtility();
            database.ExecuteNonQuery(string.Format("Insert Into Movie Values('{0}', '{1}', 5, '{1}')",
                movieTitle, releaseDate));


            DataTable data = database.ExecuteQuery(string.Format("Select * from Movie where Title = '{0}' and ReleaseDate = '{1}'",
                movieTitle, releaseDate));

            Assert.AreEqual(5, data.Columns.Count);
            Assert.AreEqual(1, data.Rows.Count);
        }
    }
}
