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
    /// Management_Window.xaml 的交互逻辑
    /// </summary>
    public partial class Management_Window : Window
    {
        public byte Wstate = 0; //当前活动窗口标识  0 部门管理
        sqlConnect con = new sqlConnect();
        public DataSet ds = new DataSet();
        private string sql;
        protected void setBind()
        {
            try
            {
                sql = "";// To Do
                if (Wstate == 0)
                {
                    sql = "SELECT Deptno AS 科室编号, Deptname AS 科室名 FROM Dept";
                }
                else if (Wstate == 1)
                {
                }
                else if (Wstate == 2) 
                {
                    sql = "SELECT Dno AS 医生编号, Dname AS 姓名, Dsex AS 性别 , Dage AS 年龄, Dprot AS 职称, Deptname AS 所属科室 FROM Doctor,Dept WHERE Doctor.Deptno=Dept.Deptno ";
                }
                con.BindDataGrid(manageDataGrid, sql);
                //manageDataGrid.Columns[0].IsReadOnly = true;
                //manageDataGrid.AllowDrop = false;
            }
            catch{ MessageBox.Show("无法操作！", "", MessageBoxButton.OK, MessageBoxImage.Information); }
        }
        public Management_Window()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Dept_Click(object sender, RoutedEventArgs e)
        {
            Wstate = 0;
            setBind();
        }

        private void Pharmacy_Click(object sender, RoutedEventArgs e)
        {
            Wstate = 1;
            setBind();
        }

        private void Doctor_Click(object sender, RoutedEventArgs e)
        {
            Wstate = 2;
            setBind();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Wstate == 0)
            {
                Dept_Window deptW = new Dept_Window();
                deptW.Owner = this;
                deptW.Show();//To Do 刷新操作
            }
            else if (Wstate == 1)
            {
                Pharmacy_Window pharW = new Pharmacy_Window();
                pharW.Owner = this;
                pharW.Show();
            }
            else if (Wstate == 2)
            {
                Doctor_Window drW = new Doctor_Window();
                drW.Owner = this;
                drW.Show();
            }
        }

    }
}
