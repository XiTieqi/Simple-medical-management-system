using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace Management_Application.Pharmacy
{
    /// <summary>
    /// PharmacyWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PharmacyWindow : Window
    {
        sqlConnect con = new sqlConnect();
        public DataSet ds = new DataSet();
        private string sql;
        string pno, pname;
        public PharmacyWindow()
        {
            InitializeComponent();
        }

        private void RXno_TextChanged(object sender, TextChangedEventArgs e)
        {
            sql = "select Pno from Prescription where RXno=" + RXno.Text;
            ds = con.Getds(sql);
            pno = ds.Tables[0].Rows[0].ItemArray[0].ToString();

            sql = "select Pname from Patient where Pno=" + pno;
            ds = con.Getds(sql);
            pname = ds.Tables[0].Rows[0].ItemArray[0].ToString();

            sql = "select  Mno as 药品编号, Mname as 药品名称 , Mnum as 药物数量,Mstate as  药物状态 , Mprice as 药品单价,  Mtype as 药片类型 from Medicine, RXM " +
                "where Medicine.Mno= RXM.Mno and RXM.RXno=" + RXno.Text;
            con.BindDataGrid(Mgrid, sql);
        }
    }
}
