using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MyCms.Data
{
    public class SqlDataProvider
    {
        static string strConStr = System.Configuration.ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

        public static SqlConnection connection;
        public SqlDataProvider()
        {
            if (connection == null) { connection = new SqlConnection(strConStr); }
            //if (connection.State != ConnectionState.Open) { connection.Open(); }
        }
        public static SqlConnection GetConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            //else
            //{
            //    SqlConnection.ClearPool(connection);
            //}            
            return connection;
        }

        #region DB Access Functions

        public DataTable GetData(string sql)
        {
            // truyền chuỗi sql, trả về database                                      
            return GetData(GetCommand(sql));
        }

        public static DataTable GetData(SqlCommand cmd)
        {
            /*  - truyền vào đối tượng sqlcommand trả về dl database
                - Dùng SqlDataAdapter thực hiện lệnh sqlcommand, điền vào dataset, trả về dữ liệu Tables
            */
            try
            {
                if (cmd.Connection == null) { cmd.Connection = GetConnection(); }
                using (DataSet ds = new DataSet())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        return ds.Tables[0];
                    }
                }
            }
            finally
            {

            }
        }

        public void ExecuteNonQuery(string sql)
        {
            // thủ tục: truyền vào chuỗi sql, thực hiện lệnh sqlcommand
            ExecuteNonQuery(GetCommand(sql));
        }

        public void ExecuteNonQuery(SqlCommand cmd)
        {
            // thủ tục: truyền vào đối tượng sqlcommand, thực hiện lệnh sqlcommand
            try
            {
                if (cmd.Connection == null) { cmd.Connection = GetConnection(); }
                cmd.ExecuteNonQuery();
            }
            finally
            {

            }
        }

        public object ExecuteScalar(string sql)
        {
            // hàm kiểu Object: truyền vào chuỗi sql, thực hiện lệnh, trả về kết quả 
            return ExecuteScalar(GetCommand(sql));
        }

        public object ExecuteScalar(SqlCommand cmd)
        {
            // hàm kiểu Object: truyền vào đối tượng sqlcommand, thực hiện lệnh, trả về kết quả 
            try
            {
                if (cmd.Connection == null) { cmd.Connection = GetConnection(); }
                return cmd.ExecuteScalar();
            }
            finally
            {

            }
        }

        private SqlCommand GetCommand(string sql)
        {
            // truyền vào chuỗi sql,  thực hiện lệnh, trả về kết quả 
            SqlCommand cmd = new SqlCommand(sql, GetConnection());
            return cmd;
        }

        public string MaxId(string Table, string ColId)
        {
            string strReturn = "";
            strReturn = ExecuteScalar("SELECT max(" + ColId + ") as maxid FROM " + Table).ToString();
            return strReturn;
        }
        public int DBSize()
        {
            using (SqlCommand cmd = new SqlCommand("select sum(size) * 8 * 1024 from sysfiles"))
            {
                cmd.CommandType = CommandType.Text;
                return (int)ExecuteScalar(cmd);
            }
        }
        #endregion
    }
}