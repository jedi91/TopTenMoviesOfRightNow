using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using DatabaseEntities;

namespace AppCache
{
    public class EntityCache
    {
        private static ObjectCache cache = MemoryCache.Default;

        public static Movie GetMovie(int movieId)
        {
            string key = string.Format("Movie_{0}", movieId);
            Movie movie = cache[key] as Movie;

            if(movie == null)
            {
                using (TopTenRightNowContext context = new TopTenRightNowContext())
                {
                    movie = context.Movies.Find(movieId);
                }

                if (movie != null)
                {
                    cache[key] = movie;
                }
            }

            return movie;
        }

        public static Movie GetMovieByTitleAndRelease(string title, DateTime releaseDate)
        {
            string key = string.Format("Movie_{0}_{1}", title, releaseDate);
            Movie movie = cache[key] as Movie;

            if(movie == null)
            {
                using (TopTenRightNowContext context = new TopTenRightNowContext())
                {
                    movie = context.Movies.
                        Where(m => m.Title == title && m.ReleaseDate == releaseDate).
                        FirstOrDefault();
                }

                if (movie != null)
                {
                    cache[key] = movie;
                }
            }

            return movie;
        }
    }
}
