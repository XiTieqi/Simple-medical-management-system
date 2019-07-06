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

namespace Management_Application.Register
{
    /// <summary>
    /// PatientWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PatientWindow : Window
    {
        string pno;
        UserWindow UsW;
        public PatientWindow(string no,UserWindow _UsW)
        {
            InitializeComponent();
            pno = no;
            UsW = _UsW;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow ReW = new RegisterWindow(pno, this);
            ReW.Show();
            this.Hide();
        }

        private void ChargeButton_Click(object sender, RoutedEventArgs e)
        {
            ChargeWindow ChW = new ChargeWindow(pno, this);
            ChW.Show();
            this.Hide();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            UsW.Visibility = Visibility.Visible;
        }
    }
}
