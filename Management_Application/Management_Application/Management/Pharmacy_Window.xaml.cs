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
using System.Data.SqlClient;
using System.Data;


namespace Management_Application.Management
{
    /// <summary>
    /// Pharmacy_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Pharmacy_Window : Window
    {
        sqlConnect con = new sqlConnect();
        public DataSet ds = new DataSet();
        private string sql;
        public Pharmacy_Window()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sql = "INSERT INTO Dept VALUES('" + TextDeptNo.Text + "','" + TextDeptName.Text + "'," + "0)";
                con.OperateData(sql);
            }
            catch
            {
                MessageBox.Show("不能进行该操作", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
