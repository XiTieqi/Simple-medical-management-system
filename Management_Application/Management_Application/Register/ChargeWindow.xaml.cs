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

namespace Management_Application.Register
{
    /// <summary>
    /// ChargeWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ChargeWindow : Window
    {
        string pno;
        PatientWindow PaW;
        sqlConnect con = new sqlConnect();
        public DataSet ds = new DataSet();
        private string sql;
        float bal, pay;
        public ChargeWindow(string no,PatientWindow _PaW)
        {
            InitializeComponent();
            pno = no;
            PaW = _PaW;
            textprint();
        }

        private void ChargeHundredButton_Click(object sender, RoutedEventArgs e)
        {
            charge(100);
        }
        private void ChargefiftyButton_Click(object sender, RoutedEventArgs e)
        {
            charge(50);
        }
        private void ChargeTenButton_Click(object sender, RoutedEventArgs e)
        {
            charge(10);
        }
        private void ChargeButton_Click(object sender, RoutedEventArgs e)
        {
            float num;
            try
            {
                num = float.Parse(Money.Text);
                charge(num);
            }
            catch
            {
                MessageBox.Show("请输入有效的值", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            PaW.Visibility = Visibility.Visible;
            this.Close();
        }
        public void charge(float num)
        {
            sql = "select Pbal from Patient where Pno ='" + pno + "'";
            ds = con.Getds(sql);
            bal = float.Parse(ds.Tables[0].Rows[0]["Pbal"].ToString());
            bal = bal + num;
            sql = "select min(Price) as 价格,RXno as 处方单号 from Prescription where Pno = '" + pno + " ' and Paystate = 0";
            ds = con.Getds(sql);
            pay = float.Parse(ds.Tables[0].Rows[0]["价格"].ToString());
            string RXno = ds.Tables[0].Rows[0]["处方单号"].ToString();
            while (bal > pay && pay > 0) 
            {
                bal = bal - pay;
                sql = " update on Prescription set Paystate = 1 where RXno = '" + RXno + "'";
            }
            sql = "update Patient set Pbal=" + string.Format("{0:000000.00}", bal) + "where Patient.Pno=" + pno;//给该用户加钱的语句
            con.OperateData(sql);
            
            textprint();
        }
        public void textprint()
        {
            DataSet ds;
            sql = "SELECT Pbal FROM Patient WHERE Pno= " + pno;
            ds = con.Getds(sql);
            this.Pbal.Content = ds.Tables[0].Rows[0]["Pbal"].ToString();
        }
    }
}
