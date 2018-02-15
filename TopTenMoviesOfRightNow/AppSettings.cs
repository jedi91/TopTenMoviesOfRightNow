using System.Configuration;

namespace TopTenMoviesOfRightNow
{
    public class AppSettings
    {
        public static string MovieDatabaseApiKey
        {
            get
            {
                return ConfigurationManager.AppSettings["movieDatabaseApiKey"].ToString();
            }
        }

        public static string SearchUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["searchUrl"].ToString();
            }
        }
    }
}