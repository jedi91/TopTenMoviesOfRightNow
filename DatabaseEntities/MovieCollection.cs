using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseEntities
{
    public class MovieCollection : List<MovieEntity>
    {        
        private string tableName;
        private IDatabaseUtility database;

        public MovieCollection()
        {
            tableName = "Movie";
            database = new SqlServerUtility();
        }

        public enum Fields
        {
            MovieId,
            Title,
            ReleaseDate,
            RankingWeight,
            LastRankedTime
        }

        public void Fetch(string columnName, object value)
        {
            string sqlQuery = CreateSqlForFetch(columnName, value);

            DataTable data = database.ExecuteQuery(sqlQuery);

            foreach (DataRow row in data.Rows)
            {
                MovieEntity movie = new MovieEntity(row);
                Add(movie);
            }
        }

        private string CreateSqlForFetch(string columnName, object value)
        {
            if(value.GetType() == typeof(string))
            {
                return string.Format("select * from {0} (nolock) where {1} = '{2}'",
                tableName, columnName, value);
            }

            return string.Format("select * from {0} (nolock) where {1} = {2}",
                tableName, columnName, value);
        }

        public void Save()
        {
            foreach(MovieEntity movie in this)
            {
                string sqlNonQuery;

                if (movie.MovieId == null)
                {
                    sqlNonQuery = CreateSqlForInsert(movie);
                }

                sqlNonQuery = CreateSqlForUpdate(movie);
                database.ExecuteNonQuery(sqlNonQuery);
            }
        }

        private string CreateSqlForInsert(MovieEntity movie)
        {
            return string.Format("Insert Into Movie Values({0}, {1}, {2}, {3})",
                movie.Title, movie.ReleaseDate, movie.RankingWeight, movie.LastRankedTime);
        }

        private string CreateSqlForUpdate(MovieEntity movie)
        {
            return string.Format("Update Movie Set {0} = '{1}', {2} = '{3}', {4} = {5}, {6} = '{7}' Where {8} = {9}",
                Fields.Title, movie.Title, Fields.ReleaseDate, movie.ReleaseDate, Fields.RankingWeight, movie.RankingWeight,
                Fields.LastRankedTime, movie.LastRankedTime, Fields.MovieId, movie.MovieId);
        }
    }
}
