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

namespace Management_Application.Dotctor
{
    /// <summary>
    /// WelcomWindow.xaml 的交互逻辑
    /// </summary>
    public partial class WelcomWindow : Window
    {
        string Dno;
        sqlConnect con = new sqlConnect();
        public DataSet ds = new DataSet();
        private string sql;

        public WelcomWindow(string _Dno)
        {
            InitializeComponent();
            Dno = _Dno;
            sql = "select Dname as 医生姓名 from Doctor where Dno=" + Dno;//查找相应的医生名称并显示
            ds = con.Getds(sql);
            Doctorname.Content = ds.Tables[0].Rows[0][0].ToString();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            DoctorMainWindow DMW = new DoctorMainWindow(Dno);
            DMW.Show();
            this.Close();
        }
    }
}
