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
    /// Doctor_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Doctor_Window : Window
    {
        sqlConnect con = new sqlConnect();
        public DataSet ds = new DataSet();
        private string sql;
        public Doctor_Window()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sql = "INSERT INTO Doctor VALUES('" + Textno.Text + "','" + Textname.Text + "','" + Textsex.Text + "','" + Date.SelectedDate + "','" + Textprot.Text + "','" + Textdept.Text + "','" + ")";
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
