
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Simple_Personnel_Management{
    class sqlConnect{

        public SqlConnection conn = null;
        public sqlConnect(){
            if (conn == null){
                conn = new SqlConnection("Data Source = (local); database = Medical_Data_Management_System ;uid = HRmanagement;password = 666666;");
                if (conn.State == ConnectionState.Closed) conn.Open();
            }
        }
        public void closeConnect() 
        {
            if (conn.State == ConnectionState.Open) conn.Close();
        }

        public DataSet Getds(string sql)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public int OperateData(String sql)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.CommandText = sql;
            sqlcom.CommandType = CommandType.Text;
            sqlcom.Connection = conn;
            int x = sqlcom.ExecuteNonQuery();
            conn.Close();
            return x;
        }
    }
}
