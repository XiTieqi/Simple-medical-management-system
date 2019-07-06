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
        public PharmacyWindow()
        {
            InitializeComponent();
        }

        private void RXno_TextChanged(object sender, TextChangedEventArgs e)
        {
            //显示病人名称
            sql = "";
            ds = con.Getds(sql);
            Pno.Content=;
            Pname.Content=;

            sql = "select  Mno as 药品编号, Mname as 药品名称 from Medicine, RXM " +
                "where Medicine.Mno = RXM.Mno and RXM.RXno=" + RXno.Text;
            con.BindDataGrid(Mgrid, sql);
        }
    }
}
