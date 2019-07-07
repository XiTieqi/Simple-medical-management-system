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
        int state = -1;
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string pass;
            if (this.username.Text == "" || this.passward.Password == "")
                MessageBox.Show("用户名或者密码不能为空！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                pass = this.passward.Password;

                //sql = "select count(*) from Account where username = " + this.username.Text + " , password=" + pass.ToString();
                //ds = con.Getds(sql);
                //if (ds.Tables[0].Rows[0][0].Equals(0))
                //{

                //}
                sql = "SELECT Permission FROM Account WHERE username='" + this.username.Text + "' AND password= '" + pass + "'";
                ds = con.Getds(sql);
                if (ds.Tables[0].Rows.Count == 0) 
                {
                    MessageBox.Show("用户名或者密码错误！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    state = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                }
                
           
                if (state == 0)
                {
                    Management.Management_Window manW = new Management.Management_Window();
                    manW.Show();
                    this.Close();
                }
                else if (state == 1)
                {
                    Register.UserWindow userW = new Register.UserWindow();
                    userW.Show();
                    this.Close();
                }
                else if (state == 2)
                {
                    Dotctor.WelcomWindow doctorW = new Dotctor.WelcomWindow(this.username.Text);
                    doctorW.Show();
                    this.Close();
                }
                else if (state == 3)
                {
                    Pharmacy.PharmacyWindow pharmacyW = new Pharmacy.PharmacyWindow();
                    pharmacyW.Show();
                    this.Close();
                }
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
