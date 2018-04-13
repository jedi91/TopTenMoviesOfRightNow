using System;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseEntities
{
    public class SqlServerUtility : IDatabaseUtility
    {
        private SqlConnection connection;

        public SqlServerUtility()
        {
            connection = new SqlConnection(DatabaseSettings.ConnectionString);
        }

        public DataTable ExecuteQuery(string queryString)
        {
            DataTable data = new DataTable();

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(queryString, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                data.Load(dataReader);

                dataReader.Close();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    string.Format("An Exeption was thrown trying to execute the following query: {0}", 
                    queryString), ex);
            }

            return data;
        }

        public void ExecuteNonQuery(string nonQueryString)
        {
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(nonQueryString, connection);
                command.ExecuteNonQuery();

                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(
                    string.Format("An Exeption was thrown trying to execute the following non-query: {0}",
                    nonQueryString), ex);
            }
        }
    }
}
