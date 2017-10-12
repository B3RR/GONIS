using System;
using System.Runtime;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace GONIS.Core.Helper
{
    public class MSSqlAdoNetHelper
    {
        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <returns>The data table.</returns>
        /// <param name="cmd">Cmd</param>
        /// <param name="con">Con</param>
        /// <param name="timeout">Timeout.</param>
        private static DataTable GetDataTable(SqlCommand cmd, SqlConnection con, int timeout)
        {
            if (con != null)
            {
                if (cmd != null)
                {
                    con.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        da.SelectCommand = cmd;
                        da.SelectCommand.CommandTimeout = timeout * 1000;
                        var ds = new DataSet();
                        da.Fill(ds);
                        cmd.Dispose();
                        return ds.Tables[0];
                    }
                }
                else throw new NullReferenceException("SqlCommand is null");
            }
            else throw new NullReferenceException("SQLConnection is null");

        }
        /// <summary>
        /// Do the sql command from string. * All char "'" will be deleted.
        /// </summary>
        /// <returns>The sql command from string.</returns>
        /// <param name="query">Query string</param>
        /// <param name="parameters">Parameters</param>
        private static SqlCommand DoSqlCommandFromString(string query, Dictionary<string, object> parameters = null)
        {
            var cmd = new SqlCommand();
            cmd.CommandText = query.Replace("'", "");
            if (parameters != null)
            {
                foreach (var kvp in parameters)
                {
                    var param = kvp.Key.Replace("@", "").Trim();
                    cmd.Parameters.AddWithValue($"@{param}", kvp.Value);
                }
            }

            return cmd;
        }
        /// <summary>
        /// Gets the data table from query.
        /// </summary>
        /// <returns>The data table from query.</returns>
        /// <param name="con">Con.</param>
        /// <param name="cmd">Cmd.</param>
        /// <param name="timeout">Timeout in seconds.</param>
        public static DataTable GetDataTableFromQuery(SqlConnection con, SqlCommand cmd, int timeout = 30)
        {
            return GetDataTable(cmd, con, timeout);
        }
        /// <summary>
        /// Gets the data table from query.
        /// </summary>
        /// <returns>The data table from query.</returns>
        /// <param name="conString">Con string.</param>
        /// <param name="cmd">Cmd.</param>
        /// <param name="timeout">Timeout in secods.</param>
        public static DataTable GetDataTableFromQuery(string conString, SqlCommand cmd,  int timeout = 30)
        {
            using (var con = new SqlConnection(conString))
            {
                return GetDataTable(cmd, con, timeout);
            }
        }
        /// <summary>
        /// Gets the data table from query.
        /// </summary>
        /// <returns>The data table from query.</returns>
        /// <param name="conString">Con string.</param>
        /// <param name="query">Query.</param>
        /// <param name="parameters">Parameters.</param>
        /// <param name="timeout">Timeout in seconds.</param>
        public static DataTable GetDataTableFromQuery(string conString, string query, Dictionary<string, object> parameters = null, int timeout = 30)
        {
            using (var con = new SqlConnection(conString))
            {
                return GetDataTable(DoSqlCommandFromString(query,parameters), con, timeout);
            }
        }
        /// <summary>
        /// Gets the data table from query.
        /// </summary>
        /// <returns>The data table from query.</returns>
        /// <param name="con">Con.</param>
        /// <param name="query">Query.</param>
        /// <param name="parameters">Parameters.</param>
        /// <param name="timeout">Timeout in seconds.</param>
        public static DataTable GetDataTableFromQuery(SqlConnection con,string query,Dictionary<string, object> parameters = null, int timeout = 30)
        {
                return GetDataTable(DoSqlCommandFromString(query, parameters), con, timeout);
        }



    }
}
