using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using Microsoft.SqlServer;
using System.Data.SqlClient;
using System.Data;
using PMA.Utils.Logger;
using PMA.SystemAnalyzer;
using PMA.ConfigManager;

namespace PMA.SystemAnalyzer
{
    public class PMADatabaseController
    {
        private static string CONNECTION_STRING = "Data Source={0};Initial Catalog=master;User Id={1};Password={2};";

        private PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;
        
        private SqlConnection connection = null;

        private string _message = string.Empty;

        //-----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message 
        {
            get
            {
                return _message;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="PMADatabaseController"/> class.
        /// </summary>
        public PMADatabaseController()
        {

        }

        //-----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="PMADatabaseController"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="user">The user.</param>
        /// <param name="password">The password.</param>
        public PMADatabaseController(string database, string user, string password)
        {
            configManager.Logger.Debug(EnumMethod.START);
            CreateDBConnection(database, user, password);
            configManager.Logger.Debug(EnumMethod.END);
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
            configManager.Logger.Debug(EnumMethod.START);
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
                configManager.Logger.Error(ex);
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
            configManager.Logger.Debug(EnumMethod.END);
            return result;
        }

        
        //-----------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Truncates the session state database.
        /// </summary>
        /// <returns></returns>
        public bool TruncateSessionStateDatabase()
        {
            configManager.Logger.Debug(EnumMethod.START);
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
                configManager.Logger.Error(ex);
                _message = ex.Message;
                result = false;
            }
            configManager.Logger.Debug(EnumMethod.END);
            return result;
        }


        /// <summary>
        /// Gets the size of the DB.
        /// </summary>
        /// <param name="dbname">The dbname.</param>
        /// <returns></returns>
        public decimal GetDBSize(string dbname)
        {
            configManager.Logger.Debug(EnumMethod.START);
            SqlDataAdapter dataAdapeter = new SqlDataAdapter("exec sp_databases",connection);
            DataSet dataset = new DataSet();

            try
            {
                dataAdapeter.Fill(dataset);

                decimal size = (from row in dataset.Tables[0].AsEnumerable()
                                where row["DATABASE_NAME"].ToString() == dbname
                                select decimal.Parse(row["DATABASE_SIZE"].ToString())).First<decimal>();
                return size / 1024;
            }
            catch (Exception ex)
            {
                configManager.Logger.Error(ex);
                _message = ex.Message;
                return 0;
            }
            finally
            {
                configManager.Logger.Debug(EnumMethod.END);
            }
        }


    }
}
