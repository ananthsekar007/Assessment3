using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Assessment3
{
    public class DbConnection
    {
        public SqlConnection conn;
        static readonly string defaultConnection = "Data Source=5CG95011NR; Initial Catalog=tournament; Integrated Security = True; Encrypt=False";
        public DbConnection()
        {
            conn = new SqlConnection(defaultConnection);
        }
        public DbConnection(string connectionString)
        {
            conn = new SqlConnection(connectionString);
        }

        public static int  ExecuteNonQuery(SqlConnection conn, string query)
        {
            SqlCommand sqlCommand = conn.CreateCommand();
            sqlCommand.CommandText = query;

            return sqlCommand.ExecuteNonQuery();
        }
    }
}
