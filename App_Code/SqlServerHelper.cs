using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

    public class SQLserverOper
    {
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <param name="sqlcon">数据库连接</param>
        public static void open(ref SqlConnection sqlcon)
        {
            try
            {
                FileStream fs = File.Open(@"D:\code\ConEduMS\Database.config", FileMode.Open);
                byte[] b = new byte[1024 ^ 10];
                fs.Read(b, 0, b.Length);
                fs.Close();
                string configStr = Encoding.UTF8.GetString(b);
                string[] param = Regex.Split(configStr, "\r\n");
                string conStr = "server=" + param[0] + ";user=" + param[1] + ";pwd=" + param[2] + ";";
                sqlcon = new SqlConnection(conStr);
                sqlcon.Open();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        /// <summary>
        /// 执行sql语句，无返回结果
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="sqlcon">数据库连接</param>
        /// <returns>受影响行数</returns>
        public static int executeSql(SqlCommand cmd)
        {
            return cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 执行sql语句，包含返回结果
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="sqlcon">数据库连接</param>
        /// <returns>数据</returns>
        public static DataSet executeSqlWithReturn(SqlCommand cmd)
        {
            DataSet dataSet = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dataSet);
            return dataSet;
        }
    }
