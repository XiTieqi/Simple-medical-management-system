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
        public ChargeWindow(string no,PatientWindow _PaW)
        {
            InitializeComponent();
            pno = no;
            PaW = _PaW;
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
            int num;
            try
            {
                num = int.Parse(Money.Text);
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
        public void charge(int num)
        {
            sql = "";//给该用户加钱的语句
            con.OperateData(sql);
            textprint();
        }
        public void textprint()
        {
            DataSet ds;
            sql = "SELECT Pbal FROM Patient WHERE Pno= " + pno;
            ds = con.Getds(sql);
            this.Pbal.Content = ds.Tables[0].Rows[0];
        }


    }
}
