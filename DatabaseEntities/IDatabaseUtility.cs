using System.Data;

namespace DatabaseEntities
{
    public interface IDatabaseUtility
    {
        void ExecuteNonQuery(string nonQueryString);
        DataTable ExecuteQuery(string queryString);
    }
}
