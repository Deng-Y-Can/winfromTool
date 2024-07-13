using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZoeWorld.DLL
{
    class AccessUser
    {
        //String connString = ConfigurationManager.ConnectionStrings["dbConnStr"].ToString(); ;
        //    connString = Properties.Settings.Default.psd;
        private static string connString = ConfigurationManager.ConnectionStrings["dbConnstr"].ConnectionString;

        /// <summary>
        /// 执行 Transact-SQL 语句并返回受影响的行数
        /// </summary>
        /// <param name="sql">执行的sql语句</param>
        /// <param name="parameters">sql语句中的参数</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql, params OleDbParameter[] parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);        //AddRange添加的是数组
                    return cmd.ExecuteNonQuery();
                }
            }


        }

        /// <summary>
        /// 执行查询，并返回查询所返回的结果集
        /// </summary>
        /// <param name="sql">执行的sql语句</param>
        /// <param name="parameters">sql语句中的参数</param>
        /// <returns></returns>
        public static object ExecuteScalar(string sql, params OleDbParameter[] parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    //方法2
                    cmd.Parameters.AddRange(parameters);        //AddRange添加的是数组
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 只用来执行查询结果比较少的sql
        /// </summary>
        /// <param name="sql">执行的sql语句</param>
        /// <param name="parameters">sql语句中的参数</param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sql, params OleDbParameter[] parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    //方法2
                    cmd.Parameters.AddRange(parameters);        //AddRange添加的是数组
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);
                    return dataset.Tables[0];           //可以查询很多表，默认第一个
                }
            }
        }
    }
}
