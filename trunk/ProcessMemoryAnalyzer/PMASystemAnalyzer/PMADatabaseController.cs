using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using Microsoft.SqlServer;
using System.Data.SqlClient;

namespace PMA.SystemAnalyzer
{
    public class PMADatabaseController
    {
        private static string CONNECTION_STRING = "Data Source={0};Initial Catalog=master;User Id={1};Password={2};";

        private SqlConnection connection = null;

        private string _message = string.Empty;
        
        public string Message 
        {
            get
            {
                return _message;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Creates the DB connection.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool CreateDBConnection(string database, string user, string password)
        {
            bool result = false;
            connection = new SqlConnection(String.Format(CONNECTION_STRING,database,user,password));
            try
            {
                connection.Open();
                connection.Close();
                result = true;
                _message = "Connection is created succesfully";
            }
            catch(SqlException ex)
            {
                _message = ex.Message;
                result = false;
            }
            finally
            {
                if(connection != null)
                {
                    connection.Close();
                }
            }

            return result;
        }

        
        //-----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Truncates the session state database.
        /// </summary>
        /// <returns></returns>
        public bool TruncateSessionStateDatabase()
        {
            //connection.Open();
            bool result = false;
            SqlCommand query = null;
            try
            {
                query = new SqlCommand("ALTER DATABASE [ASPState] SET  SINGLE_USER WITH NO_WAIT",connection);
                query.ExecuteNonQuery();
                query = new SqlCommand("ALTER DATABASE [ASPState] SET  SINGLE_USER ", connection);
                query.ExecuteNonQuery();
                connection.ChangeDatabase("ASPState");
                query = new SqlCommand("Truncate TABLE ASPStateTempSessions", connection);
                query.ExecuteNonQuery();
                query = new SqlCommand("Truncate TABLE ASPStateTempSessions", connection);
                query.ExecuteNonQuery();
                connection.ChangeDatabase("master");
                query = new SqlCommand("ALTER DATABASE [ASPState] SET  MULTI_USER WITH NO_WAIT", connection);
                query.ExecuteNonQuery();
                query = new SqlCommand("ALTER DATABASE [ASPState] SET  MUTI_USER ", connection);
                query.ExecuteNonQuery();
                _message = "Session State is truncated succesfully";
                result = true;
            }
            catch(SqlException ex)
            {
                _message = ex.Message;
                result = false;
            }
            return result;

        }
    }
}
