using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseEntities
{
    public class DatabaseSettings
    {
        public static string ConnectionString
        {
            get
            {
                return string.Format("Server={0};Database={1};Trusted_Connection=True;",
                    "localhost", "TopTenRightNow");
            }
        }
    }
}
