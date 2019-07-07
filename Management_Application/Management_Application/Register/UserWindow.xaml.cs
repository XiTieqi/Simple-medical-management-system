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
    /// UserWindow.xaml 的交互逻辑
    /// </summary>
    public partial class UserWindow : Window
    {
        sqlConnect con = new sqlConnect();
        public DataSet ds = new DataSet();
        private string sql;
        public UserWindow()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
           // string sql;
            sql = "SELECT ISNULL((SELECT TOP(1) 1 FROM Patient WHERE Pno=" + Pno.Text + "), 0)";
            try
            {
                ds = con.Getds(sql);
            }
            catch
            {
                MessageBox.Show("请输入正确的账号");
            }
            
            if (ds.Tables[0].Rows[0][0].Equals(0))
            {
                MessageBox.Show("账户不存在！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                PatientWindow paW = new PatientWindow(Pno.Text, this);
                paW.Show();
                this.Hide();
            }
            Pno.Text = "";
        }

        private void EnroButton_Click(object sender, RoutedEventArgs e)
        {
            EnrollWindow EnW = new EnrollWindow(this);
            EnW.Show();
            this.Hide();
        }
    }
}
