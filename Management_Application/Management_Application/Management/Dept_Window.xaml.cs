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
    /// Dept_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Dept_Window : Window
    {
        sqlConnect con = new sqlConnect();
        public DataSet ds = new DataSet();
        private string sql;
        public Dept_Window()
        {
            InitializeComponent();
        }
        public string AddData()
        {
            this.Show();

        }
        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            }
        }
    }



}
