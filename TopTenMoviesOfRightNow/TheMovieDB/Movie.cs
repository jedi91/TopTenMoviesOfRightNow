using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TopTenMoviesOfRightNow.TheMovieDB.ApiResponse;

namespace TopTenMoviesOfRightNow.TheMovieDB
{
    public class Movie
    {
        private string poster_path;
        private string overview;
        private string release_date;
        private string title;

        public string Title {
            get { return title; }
        }

        public string ImagePath
        {
            get { return poster_path; }
        }

        public string ReleaseDate
        {
            get { return release_date; }
        }

        public string Overview
        {
            get { return overview; }
        }

        public Movie(Result searchResult)
        {
            poster_path = searchResult.poster_path;
            overview = searchResult.overview;
            release_date = searchResult.release_date;
            title = searchResult.title;
        }
    }
}