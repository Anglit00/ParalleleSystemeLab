using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Backend
{
    public class DataAccess
    {
        public List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionString)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                List<T> rows = conn.Query<T>(sqlStatement, parameters).ToList();
                return rows;
            }
        }

        public void SaveData<T>(string sqlStatement, T parameters, string connectionString)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                conn.Execute(sqlStatement, parameters);
            }
        }
    }
}
