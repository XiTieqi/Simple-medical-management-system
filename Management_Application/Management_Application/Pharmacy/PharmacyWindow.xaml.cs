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

        private void Mgrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Mgrid.SelectedIndex != -1)
            {
                var b = (DataRowView)Mgrid.SelectedItem;
                string mno = b["药品编号"].ToString();
                sql = "update RXM set Mstate = 1 where RXno = '" + RXno.Text + "'and Mno= '" + mno + "'";
                con.OperateData(sql);

                setgrid();
            }
                

        }

        private void RXno_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                sql = "select Pno from Prescription where RXno=" + RXno.Text;
                try
                {
                    ds = con.Getds(sql);
                    pno = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    Pno.Content = pno;
                    sql = "select Pname from Patient where Pno=" + pno;
                    ds = con.Getds(sql);
                    pname = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                    Pname.Content = pname;
                    setgrid();
                }
                catch
                {
                    MessageBox.Show("药方单号错误");
                }
                RXno.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
            
        }

        private void setgrid()
        {
            sql = "select  RXM.Mno as 药品编号, Medicine.Mname as 药品名称 , RXM.Mnum as 药物数量,RXM.Mstate as  药物状态 , Medicine.Mprice as 药品单价, Medicine.Mtype as 药片类型 from Medicine, RXM where Medicine.Mno= RXM.Mno and RXM.RXno=" + RXno.Text;
            ds = con.Getds(sql);
            Mgrid.ItemsSource = ds.Tables[0].DefaultView;
        }
        




    }
}
