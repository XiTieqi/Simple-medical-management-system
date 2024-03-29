﻿using System;
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

namespace Management_Application.Register
{
    /// <summary>
    /// EnrollWindow.xaml 的交互逻辑
    /// </summary>
    public partial class EnrollWindow : Window
    {
        sqlConnect con = new sqlConnect();
        public DataSet ds = new DataSet();
        private string sql;
        UserWindow useW;
        List<string> sex = new List<string>();
        public EnrollWindow(UserWindow _useW)
        {
            InitializeComponent();
            useW = _useW;
            sex.Add("男");
            sex.Add("女");
            Sex.ItemsSource = sex;
        }

        private void EnrollButton_Click(object sender, RoutedEventArgs e)
        {
           // string sql;
            sql = "SELECT ISNULL((SELECT TOP(1) 1 FROM  Patient WHERE Pno=" + Pno.Text + "), 0)";
            ds = con.Getds(sql);
            if (ds.Tables[0].Rows[0][0].Equals(0))
            {
                sql = "insert into patient values('" + Pno.Text + "','" + Textname.Text + "','" + Sex.Text + "','" + Date.SelectedDate.Value.Date.ToShortDateString() + "',0)";//新加一个病人账户的语句
                try
                {
                    con.OperateData(sql);
                }
                catch
                {
                    MessageBox.Show("请输入正确的信息");
                }
                useW.Visibility = Visibility.Visible;
                this.Close();
            }
            else
            {
                MessageBox.Show("账户已存在！", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            useW.Visibility = Visibility.Visible;
            this.Close();
        }


    }
}
