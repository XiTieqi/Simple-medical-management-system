
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
//using System.Windows.Forms;

namespace Management_Application
{
    class sqlConnect
    {

        public SqlConnection conn = null;
        public sqlConnect()
        {
            if (conn == null)
            {
                string Loginsql = @"server = TIEQIDEPAVILION\SQLEXPRESS; database = Medical_Data_Management_System; uid = Medical_Data_Management; pwd = 666666";
                conn = new SqlConnection(Loginsql);
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

        public DataSet BindDataGrid(DataGrid dg, string sql)
        {
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dg.DataContext = ds.Tables[0];
            return ds;
        }
    }
}
