using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Cryptography;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace Management_Application
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        sqlConnect con = new sqlConnect();
        public DataSet ds = new DataSet();
        private string sql;
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string pass;
            if (this.username.Text == "" || this.passward.Text == "")
                MessageBox.Show("用户名或者密码不能为空！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            try
                {
                    pass = this.passward.Text;
                    pass = MD5Encrypt32(pass);
                }
            catch
                {
                  

                    MessageBox.Show("用户名或者密码错误！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                }
        }
        public string MD5Encrypt32(string password)//32位MD5加密
        {
            string cl = password;
            string pwd = "";
            MD5 md5 = MD5.Create();
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            for (int i = 0; i < s.Length; i++)
            {
                pwd = pwd + s[i].ToString("X");
            }
            return pwd;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
