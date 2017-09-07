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
        private bool adult;
        private string overview;
        private string release_date;
        private int[] genre_ids;
        private int id;
        private string original_title;
        private string original_language;
        private string title;
        private string backdrop_path;
        private decimal popularity;
        private int vote_count;
        private bool video;
        private decimal vote_average;

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
            adult = searchResult.adult;
            overview = searchResult.overview;
            release_date = searchResult.release_date;
            genre_ids = searchResult.genre_ids;
            id = searchResult.id;
            original_title = searchResult.original_title;
            original_language = searchResult.original_language;
            title = searchResult.title;
            backdrop_path = searchResult.backdrop_path;
            popularity = searchResult.popularity;
            vote_count = searchResult.vote_count;
            video = searchResult.video;
            vote_average = searchResult.vote_average;
        }
    }
}