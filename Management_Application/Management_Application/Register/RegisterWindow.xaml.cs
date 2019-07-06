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

namespace Management_Application.Register
{
    /// <summary>
    /// RegisterWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterWindow : Window
    {
        string pno;
        PatientWindow PaW;
        public RegisterWindow(string no,PatientWindow _PaW)
        {
            InitializeComponent();
            pno = no;
            PaW = _PaW;
        }
        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            PaW.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
